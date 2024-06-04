using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BuffData_", menuName = "ScriptableObjects/BuffDataSO")]
public class BuffDataSO : ScriptableObject
{
    public string buffName;
    public string describe;
    public int cost;
    public int sale;
    public Rarity rarity;

    public int energy;
    public int ratio;
    public int technologyPoints;
}
