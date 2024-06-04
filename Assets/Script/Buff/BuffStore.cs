using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffStore : MonoBehaviour
{
    public GameObject buffPrefab;
    public List<Transform> Columns;
    List<BuffDataSO> buffs;


    public static BuffStore instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        buffs = GameResources.Instance.buffDataSOs;
    }

    /// <summary>
    /// 购买buff
    /// </summary>
    public void BuyBuff()
    {

    }

    /// <summary>
    /// 将所买的buff添加至商品栏
    /// </summary>
    public void AddBuffToColumn()
    {

    }

    /// <summary>
    /// 将所买的buff添加至buff栏
    /// </summary>
    public void AddBuffToBuffDeck()
    {

    }

}
