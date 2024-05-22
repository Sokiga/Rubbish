using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    int BasicScore = 0;
    int BasicTime = 0;
    public enum HandType
    {
        SuperBattery,
        BigBattery,
        LevelTen,
        None
    }

    public static HandType EvaluateHand(List<Card> hand)
    {
        int tenCount = 0;
        for (int i = 0; i < 5; i++)
        {
            for (int j = i + 1; j < 5; j++)
            {
                for (int k = j + 1; k < 5; k++)
                {
                    if ((hand[i].Value + hand[j].Value + hand[k].Value) % 10 == 0)
                    {
                        tenCount++;
                    }
                }
            }
        }

        if (tenCount >= 3)
        {
            // 检查是否为同花色
            Suit suit = hand[0].Suit;
            if (hand.All(card => card.Suit == suit))
            {
                // 检查点数是否满足条件
                if (hand.All(card => card.Value > 10))
                {
                    int BasicScore = 500;
                    int BasicTime = 20;
                }
            }
            // 如果没有满足条件的牌型，返回BigBattery
            return HandType.BigBattery;

            if (hand.All(card => card.Value < 10))
            {
                int BasicScore = 100;
                int BasicTime = 20;
            }
            // 如果没有满足条件的牌型，返回LevelTen
            return HandType.LevelTen;
            
            // 继续计算剩余两张牌的点数和
            int sum = hand[4].Value + hand[0].Value;
            int cowNumber = sum % 10;
            if (cowNumber == 0)
            {
                return HandType.LevelTen;
            }
            return HandType.None;
            

        }

        else if (tenCount >= 3)
        {
            
        }

        // 如果没有找到三张牌可以组成10的整数倍，则返回None
        return HandType.None;
    }
    public int CalculateScore(HandType handType, int cowCount)
    {
        // 实现计算积分的逻辑

        return 0;
    }
}