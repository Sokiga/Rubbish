using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int CalculateScore(HandType handType, int cowCount)
    {
        // 实现计算积分的逻辑
        return 0;
    }
}

[System.Serializable]
public enum HandType
{
    Battery,
    BigBattery,
    SuperBattery,
}