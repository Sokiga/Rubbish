using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    [Header("DATA")]
    public TextAsset cardData;
    public GameObject cardPrefab;

    [Space(5)]
    [Header("UI")]
    public Transform cardPool;
    public Transform buffPool;

    [Space(5)]
    [Header("DECK")]
    [Tooltip("抽牌堆")]
    public List<CardData> deck;
    [Tooltip("手牌")]
    public List<Card> handCardDeck;
    [Tooltip("BUFF")]
    public List<Buff> buffDeck;

    public static CardManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    /// <summary>
    /// 初始化牌堆，包含39张牌（3种花色，每种花色13张牌）
    /// </summary>
    public void InitializeDeck(TextAsset cardData)
    {
        deck.Clear();
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
        if (ScoreManager.instance.currentDiscardTime == 0) return;

        ScoreManager.instance.currentDiscardTime--;
        ScoreManager.instance.UIDiscardTime.text = ScoreManager.instance.currentDiscardTime.ToString();
        // 将所选中的手牌从手牌中删除并添加到牌堆中
        int counter = 0;
        List<Card> cardToDelete = new List<Card>();
        foreach (Card handCard in handCardDeck)
        {
            if (handCard.isSelected)
            {
                cardToDelete.Add(handCard);
                deck.Add(handCard.cardData);
                Destroy(handCard.gameObject);
                counter++;
            }
        }

        handCardDeck.RemoveAll(x => cardToDelete.Contains(x));
        DrawCard(counter);
    }

    /// <summary>
    /// 回收
    /// </summary>
    public void PlayCard()
    {
        ScoreManager.instance.currentPlayTime--;
        ScoreManager.instance.UIPlayTime.text = ScoreManager.instance.currentPlayTime.ToString();
        ScoreManager.instance.DetermineCardType(handCardDeck);
        ScoreManager.instance.CalculateTotalEnergy(handCardDeck, buffDeck);

        List<Card> cardsToRemove = new List<Card>();
        foreach (Card handCard in handCardDeck)
        {
            cardsToRemove.Add(handCard);
            Destroy(handCard.gameObject);
        }
        handCardDeck.RemoveAll(x => cardsToRemove.Contains(x));

        if (!ScoreManager.instance.CheckIsDown())
        {
            DrawCard(5);
        }
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

        foreach (CardData card in handDeck)
        {
            Card currentCard = Instantiate(cardPrefab, cardPool).GetComponent<Card>();
            currentCard.InitCard(card);
            handCardDeck.Add(currentCard);
        }
    }

}
