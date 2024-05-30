using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int targetEnergy;
    public int currentTotalEnergy;
    public int currentEnergy;
    public int currentRatio;

    public static ScoreManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void CalculateAndCheckTotalEnergy(List<Card> handDeck)
    {
        currentEnergy = 0;
        currentRatio = 0;
        Suit firstSuit = handDeck[0].cardData.suit;

        int[] points = handDeck.Select(x => Mathf.Min(10, x.cardData.value)).ToArray();

        if (IsGreatBoom(points, handDeck, firstSuit))
        {
            currentEnergy = 200;
            currentRatio = 20;
            return;
        }

        if (IsBoom(points))
        {
            currentEnergy = 150;
            currentRatio = 20;
            return;
        }

        for (int i = 0; i < points.Length - 2; i++)
        {
            for (int j = i + 1; j < points.Length - 1; j++)
            {
                for (int k = j + 1; k < points.Length; k++)
                {
                    int sum = points[i] + points[j] + points[k];
                    if (sum % 10 == 0)
                    {
                        // 剩下的两张牌的点数之和
                        int remainingSum = points.Sum() - sum;
                        int niu = remainingSum % 10;

                        MatchEnemyRatio(niu);
                    }
                }
            }
        }
    }

    /// <summary>
    /// 判断是不是大电池
    /// </summary>
    private bool IsGreatBoom(int[] points, List<Card> handDeck, Suit firstSuit)
    {
        foreach (int point in points)
        {
            if (point < 10)
            {
                return false;
            }
        }

        foreach (Card handCard in handDeck)
        {
            if (handCard.cardData.suit != firstSuit)
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// 判断是不是电池
    /// </summary>
    private bool IsBoom(int[] points)
    {
        foreach (int point in points)
        {
            if (point < 10)
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// 匹配能量倍率
    /// </summary>
    private void MatchEnemyRatio(int niu)
    {
        switch (niu)
        {
            case 0:
                currentEnergy = 125;
                currentRatio = 10;
                break;
            case 1:
                currentEnergy = 5;
                currentRatio = 10;
                break;
            case 2:
                currentEnergy = 5;
                currentRatio = 10;
                break;
            case 3:
                currentEnergy = 5;
                currentRatio = 10;
                break;
            case 4:
                currentEnergy = 5;
                currentRatio = 10;
                break;
            case 5:
                currentEnergy = 25;
                currentRatio = 10;
                break;
            case 6:
                currentEnergy = 25;
                currentRatio = 10;
                break;
            case 7:
                currentEnergy = 25;
                currentRatio = 10;
                break;
            case 8:
                currentEnergy = 25;
                currentRatio = 10;
                break;
            case 9:
                currentEnergy = 25;
                currentRatio = 10;
                break;
            default:
                break;
        }
    }

}