using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    public TextAsset cardData;
    public GameObject cardPrefab;
    public Transform cardPool;
    public Transform score;

    [Space(5)]
    [Header("DECK")]
    [Tooltip("抽牌堆")]
    public List<CardData> deck;
    [Tooltip("手牌")]
    public List<Card> handCardDeck;
    // public List<Buff> buffDeck;

    [Space(5)]
    [Tooltip("弃牌次数")]
    public int discardTimes;
    [Tooltip("出牌次数")]
    public int playTimes;


    public static CardManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        InitializeDeck(cardData); // 初始化牌堆
        DealCard(); // 发初始手牌
    }

    /// <summary>
    /// 洗牌
    /// </summary>
    private void Shuffle(List<CardData> list)
    {
        System.Random random = new System.Random();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = random.Next(n + 1);
            CardData value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    /// <summary>
    /// 抽牌
    /// </summary>
    private void DrawCard(int number)
    {
        Shuffle(deck);

        List<CardData> handDeck = new List<CardData>(deck.GetRange(0, number));
        deck.RemoveAll(x => handDeck.Contains(x));

        handCardDeck.Clear();
        foreach (CardData card in handDeck)
        {
            Card currentCard = Instantiate(cardPrefab, cardPool).GetComponent<Card>();
            currentCard.InitCard(card);
            handCardDeck.Add(currentCard);
        }
    }

    /// <summary>
    /// 初始化牌堆，包含39张牌（3种花色，每种花色13张牌）
    /// </summary>
    public void InitializeDeck(TextAsset cardData)
    {
        var rows = cardData.text.Split("\n");
        foreach (var row in rows)
        {
            var cell = row.Split(",");
            string type = cell[0];
            Suit suit = Suit.Electronic;
            switch (type)
            {
                case "Electronic":
                    suit = Suit.Electronic;
                    break;
                case "Biological":
                    suit = Suit.Biological;
                    break;
                case "Foundational":
                    suit = Suit.Foundational;
                    break;
                default:
                    Debug.Log("No Type");
                    break;
            }

            int id = int.Parse(cell[1]);
            int value = int.Parse(cell[2]);
            int energy = int.Parse(cell[3]);

            CardData _cardData = new CardData()
            {
                id = id,
                suit = suit,
                value = value,
                energy = energy,
            };
            deck.Add(_cardData);
        }
    }

    /// <summary>
    /// 发初始手牌，从牌堆顶部抽取5张牌到玩家手牌
    /// </summary>
    public void DealCard()
    {
        Transform[] transforms = cardPool.GetComponentsInChildren<Transform>();
        if (transforms.Length > 0)
        {
            foreach (Transform card in transforms)
            {
                if (card.parent == cardPool)
                {
                    Destroy(card.gameObject);
                }
            }
        }

        DrawCard(5);
    }

    /// <summary>
    /// 弃牌
    /// </summary>
    public void DiscardCard()
    {
        // 将所选中的手牌从手牌中删除并添加到牌堆中
        int counter = 0;
        foreach (Card handCard in handCardDeck)
        {
            if (handCard.isSelected)
            {
                handCardDeck.Remove(handCard);
                deck.Add(handCard.cardData);
                counter++;
            }
        }

        DrawCard(counter);
    }

    /// <summary>
    /// 回收
    /// </summary>
    public void PlayCard()
    {
        ScoreManager.instance.CalculateAndCheckTotalEnergy(handCardDeck);

        foreach (Card handCard in handCardDeck)
        {
            handCardDeck.Remove(handCard);
            deck.Add(handCard.cardData);
        }
        DrawCard(5);
    }


}
