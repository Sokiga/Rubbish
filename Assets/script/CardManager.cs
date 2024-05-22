using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

public class CardManager : MonoBehaviour
{
    public TextAsset cardData;
    public GameObject cardPrefab;
    public Transform cardPool;

    public List<Card> deck; // 牌堆
    public List<Card> hand; // 手牌

    private void Start()
    {
        InitializeDeck(); // 初始化牌堆
        ShuffleDeck(); // 洗牌
        DealInitialHand(); // 发初始手牌
    }

    // 初始化牌堆，包含39张牌（3种花色，每种花色13张牌）
    public void InitializeDeck()
    {
        var rows = cardData.text.Split("\n");
        foreach (var row in rows)
        {
            var cell = row.Split(",");
            int Id = int.Parse(cell[1]);
            string type = cell[0];
            Suit suit = Suit.Electronic;
            if (type == "Electronic")
            {
                suit = Suit.Electronic;
            }
            else if (type == "Biological")
            {
                suit = Suit.Biological;
            }
            else if (type == "Foundational")
            {
                suit = Suit.Foundational;
            }
            else
            {
                Debug.Log("No Type");
            }
            int Value = int.Parse(cell[2]);
            int Score = int.Parse(cell[3]);

            Card card = new Card(Id, suit, Value, Score);
            deck.Add(card);
        }
    }

    // 洗牌，将牌堆中的牌随机排序
    public void ShuffleDeck()
    {
        Shuffle(deck);
    }

    void Shuffle(List<Card> list)
    {
        System.Random random = new System.Random();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = random.Next(n + 1);
            Card value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    // 发初始手牌，从牌堆顶部抽取5张牌到玩家手牌
    public void DealInitialHand()
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

        hand = new List<Card>(deck.GetRange(0, 5));
        ShuffleDeck();

        foreach (Card card in hand)
        {
            CardDisplay currentCard = Instantiate(cardPrefab, cardPool).GetComponent<CardDisplay>();
            currentCard.InitData(card);
        }
    }
}
