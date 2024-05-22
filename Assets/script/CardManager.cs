using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardManager : MonoBehaviour
{
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
        deck = new List<Card>();
        foreach (Suit suit in Enum.GetValues(typeof(Suit)))
        {
            for (int i = 1; i <= 13; i++)
            {
                deck.Add(new Card { Suit = suit, Value = i });
            }
        }
    }

    // 洗牌，将牌堆中的牌随机排序
    public void ShuffleDeck()
    {
        System.Random random = new System.Random();
        deck = deck.OrderBy(x => random.Next()).ToList();
    }

    // 发初始手牌，从牌堆顶部抽取5张牌到玩家手牌
    public void DealInitialHand()
    {
        hand = new List<Card>(deck.GetRange(0, 5));
        deck.RemoveRange(0, 5);
    }

    // 弃牌并抽新牌，玩家弃掉一些手牌并从牌堆中抽取等量的新牌
    public void DiscardAndDrawCards(int numCardsToDiscard)
    {
        if (numCardsToDiscard > hand.Count)
        {
            numCardsToDiscard = hand.Count;
        }

        // 创建一个临时牌堆，它是原始牌堆的副本
        List<Card> tempDeck = new List<Card>(deck);

        // 从手牌中弃掉卡牌
        for (int i = 0; i < numCardsToDiscard; i++)
        {
            Card cardToDiscard = hand[i];
            deck.Add(cardToDiscard);
            hand.RemoveAt(i);
        }

        // 从临时牌堆中抽取新牌
        DrawCardsFromTempDeck(numCardsToDiscard, tempDeck);

        // 更新原始牌堆，移除现在在玩家手牌中的卡牌
        deck.RemoveAll(card => hand.Contains(card));
    }

    // 从临时牌堆中抽取指定数量的卡牌
    private void DrawCardsFromTempDeck(int numCardsToDraw, List<Card> tempDeck)
    {
        System.Random random = new System.Random();

        for (int i = 0; i < numCardsToDraw; i++)
        {
            if (tempDeck.Count > 0)
            {
                int randomIndex = random.Next(tempDeck.Count);
                Card randomCard = tempDeck[randomIndex];
                hand.Add(randomCard);
                tempDeck.RemoveAt(randomIndex);
            }
            else
            {
                // 如果临时牌堆中没有卡牌，则不抽取新牌
                break;
            }
        }
    }
}
