using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BuffStore : MonoBehaviour
{
    public GameObject buffPrefab;
    public List<Transform> Columns;
    List<BuffDataSO> buffData = new List<BuffDataSO>();
    List<Buff> buffs = new List<Buff>();

    public bool isInStore = false;

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
        buffData = GameResources.Instance.buffDataSOs;
    }

    /// <summary>
    /// 购买buff
    /// </summary>
    public void BuyBuff(BuffDataSO buffData)
    {
        if (isInStore)
        {
            Buff buffInstance = Instantiate(buffPrefab, CardManager.instance.buffPool).GetComponent<Buff>();
            buffInstance.Init(buffData);
            CardManager.instance.buffDeck.Add(buffInstance);
        }
    }

    /// <summary>
    /// 将buff添加至商品栏
    /// </summary>
    public void AddBuffToColumn()
    {
        buffs.Clear();
        List<BuffDataSO> tempData = HelperUtilities.GetRandomElements(buffData, 4);
        for (int i = 0; i < tempData.Count; i++)
        {
            Buff buffInstance = Instantiate(buffPrefab, Columns[i]).GetComponent<Buff>();
            buffInstance.Init(tempData[i]);
            buffs.Add(buffInstance);
        }
    }

    public void QuitStore()
    {
        UIManager.Instance.ConversionSelectPanel();
        SelectedPanel.Instance.AddSelectCell();
        ScoreManager.instance.InitializeTimes();
    }
}
