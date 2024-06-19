using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [Header("UI")]
    public Text UITargetEnergy;
    public Text UITotalEnergy;
    public Text UICurrentEnergy;
    public Text UICurrentRatio;
    public Text UICurrentTechnologyPoints;
    public Text UICardType;
    public Text UIPlayTime;
    public Text UIDiscardTime;

    [Space(5)]
    [Header("DATA")]
    public int targetEnergy;
    public int totalEnergy;
    public int niu;
    public int getTechnologyPoint;
    int currentEnergy;
    int currentRatio;
    [SerializeField] int currentTechnologyPoints;

    [Header("出牌与弃牌次数")]
    public int maxPlayTime = 4;
    public int maxDiscardTime = 4;
    [HideInInspector] public int currentPlayTime;
    [HideInInspector] public int currentDiscardTime;

    public static ScoreManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        InitializeTimes();
    }

    public void InitializeTimes()
    {
        currentPlayTime = maxPlayTime;
        UIPlayTime.text = currentPlayTime.ToString();
        currentDiscardTime = maxDiscardTime;
        UIDiscardTime.text = currentDiscardTime.ToString();
    }

    public void SetTargetEnergy(int targetEnergy)
    {
        this.targetEnergy = targetEnergy;
        UITargetEnergy.text = targetEnergy.ToString();
    }

    /// <summary>
    /// 增加能量
    /// </summary>
    public void AddEnergy(int energy)
    {
        currentEnergy += energy;
    }

    /// <summary>
    /// 增加倍率
    /// </summary>
    public void AddRatio(int ratio)
    {
        currentRatio += ratio;
    }



    #region 判定牌型
    /// <summary>
    /// 确定牌型并给定初始能量与倍率
    /// </summary>
    public void DetermineCardType(List<Card> handDeck)
    {
        Suit firstSuit = handDeck[0].cardData.suit;
        int[] points = handDeck.Select(x => Mathf.Min(10, x.cardData.value)).ToArray();

        if (IsGreatBoom(points, handDeck, firstSuit))
        {
            InitializeUIAndData(200, 20);
            return;
        }

        if (IsBoom(points))
        {
            InitializeUIAndData(150, 20);
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
                        niu = remainingSum % 10;

                        MatchEnemyRatio(niu);
                    }
                }
            }
        }
    }

    /// <summary>
    /// 初始化UI与数据
    /// </summary>
    private void InitializeUIAndData(int energy, int ratio)
    {
        currentEnergy = energy;
        UICurrentEnergy.text = energy.ToString();
        currentRatio = ratio;
        UICurrentRatio.text = ratio.ToString();
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
                InitializeUIAndData(125, 10);
                break;
            case 1:
                InitializeUIAndData(5, 10);
                break;
            case 2:
                InitializeUIAndData(5, 10);
                break;
            case 3:
                InitializeUIAndData(5, 10);
                break;
            case 4:
                InitializeUIAndData(5, 10);
                break;
            case 5:
                InitializeUIAndData(25, 10);
                break;
            case 6:
                InitializeUIAndData(25, 10);
                break;
            case 7:
                InitializeUIAndData(25, 10);
                break;
            case 8:
                InitializeUIAndData(25, 10);
                break;
            case 9:
                InitializeUIAndData(25, 10);
                break;
            default:
                break;
        }
    }
    #endregion 判定牌型

    #region  计算总能量
    /// <summary>
    /// 计算总能量
    /// </summary>
    public void CalculateTotalEnergy(List<Card> cards, List<Buff> buffs)
    {
        CalculateValue(cards);
        CalculateBuff(buffs);

        totalEnergy += currentEnergy * currentRatio;
        UITotalEnergy.text = totalEnergy.ToString();
    }

    /// <summary>
    /// 计算所有牌的值
    /// </summary>
    /// <param name="handDeck"></param>
    private void CalculateValue(List<Card> handDeck)
    {
        int[] points = handDeck.Select(x => x.cardData.energy).ToArray();

        foreach (int energy in points)
        {
            currentEnergy += energy;
            UICurrentEnergy.text = currentEnergy.ToString();
        }
    }

    /// <summary>
    /// 计算所有BUFF
    /// </summary>
    /// <param name="buffs"></param>
    private void CalculateBuff(List<Buff> buffs)
    {
        foreach (Buff buff in buffs)
        {
            buff.triggerBuffEvent.CallTriggerBuffEvent(currentEnergy, currentRatio, currentTechnologyPoints);
        }
    }
    #endregion 计算总能量

    #region 判断
    /// <summary>
    /// 是否没有回收次数
    /// </summary>
    private bool IsOutPlayTime()
    {
        return currentPlayTime <= 0;
    }

    /// <summary>
    /// 是否当前分数超过目标分数
    /// </summary>
    public bool IsOutTargetEnergy()
    {
        return totalEnergy > targetEnergy;
    }

    public bool CheckIsDown()
    {
        if (IsOutTargetEnergy())
        {
            currentTechnologyPoints += getTechnologyPoint;
            UIManager.Instance.ConversionStorePanel();
            BuffStore.instance.AddBuffToColumn();
            totalEnergy = 0;
            UITotalEnergy.text = "0";
            Debug.Log("win");
            return true;
        }
        else if (IsOutPlayTime())
        {
            Debug.Log("fail");
            return true;
        }

        return false;
    }
    #endregion 判断
}