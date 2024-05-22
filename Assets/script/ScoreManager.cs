using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public int EvaluateHand(List<Card> hand)
    {
        if (hand.All(x => x.Suit == hand[0].Suit) && hand.All(x => x.Value >= 10))
        {
            return 10000;
        }
        else if (hand.All(x => x.Suit == hand[0].Suit) && !hand.All(x => x.Value >= 10))
        {
            return 2000;
        }


        int[] points = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10 };

        int sum = 0;
        foreach (Card card in hand)
        {
            sum += card.Value;
        }

        int remainingSum = 0;
        for (int i = 0; i < 5; i++)
        {
            for (int j = i + 1; j < 5; j++)
            {
                for (int k = j + 1; k < 5; k++)
                {
                    int total = points[hand[i].Value] + points[hand[j].Value] + points[hand[k].Value];
                    if (total % 10 == 0)
                    {
                        // 计算剩余两张牌的点数之和的个位数
                        remainingSum = (sum - total) % 10;
                    }
                }
            }
        }

        switch (remainingSum)
        {
            case 0:
                return 500;
            case 9:
                return 400;
            case 8:
                return 300;
            case 7:
                return 200;
            case 6:
                return 100;
            case 5:
                return 80;
            case 4:
                return 60;
            case 3:
                return 40;
            case 2:
                return 20;
            case 1:
                return 10;
            default:
                return 0;
        }

    }
}