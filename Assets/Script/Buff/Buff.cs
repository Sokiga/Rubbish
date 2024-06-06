using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[Serializable]
public enum Rarity
{
    Normal,
    Advanced,
    Peak,
}

[RequireComponent(typeof(TriggerBuffEvent))]
[RequireComponent(typeof(BuffFunction))]
public class Buff : MonoBehaviour, IPointerClickHandler
{
    public string buffName;
    public string describe;
    public int cost;
    public int sale;
    public Rarity rarity;

    public int energy;
    public int ratio;
    public int technologyPoints;
    public UnityEvent<int, int, int> buffEvent;


    [HideInInspector] public TriggerBuffEvent triggerBuffEvent;
    [HideInInspector] public BuffDataSO buffData;
    Text UIBuffName;
    Text UIDescribe;
    Text UICost;
    Text UIRarity;

    public void Init(BuffDataSO buffData)
    {
        buffName = buffData.buffName;
        describe = buffData.describe;
        cost = buffData.cost;
        sale = buffData.sale;
        rarity = buffData.rarity;

        energy = buffData.energy;
        ratio = buffData.ratio;
        technologyPoints = buffData.technologyPoints;

        this.buffData = buffData;
    }

    private void Awake()
    {
        UIBuffName = transform.Find("BuffName").GetComponent<Text>();
        UIDescribe = transform.Find("BuffDescribe").GetComponent<Text>();
        UICost = transform.Find("Cost").GetComponent<Text>();
        UIRarity = transform.Find("Rarity/rarity").GetComponent<Text>();

        triggerBuffEvent = transform.GetComponent<TriggerBuffEvent>();
    }

    private void Start()
    {
        UIBuffName.text = buffName;
        UIDescribe.text = describe;
        UICost.text = "BUY:" + cost.ToString();
        UIRarity.text = rarity.ToString();
    }

    private void OnEnable()
    {
        triggerBuffEvent.OnTriggerBuffEnter += TriggerBuffEvent_OnTriggerBuffEnter;
    }

    private void OnDisable()
    {
        triggerBuffEvent.OnTriggerBuffEnter -= TriggerBuffEvent_OnTriggerBuffEnter;
    }

    private void TriggerBuffEvent_OnTriggerBuffEnter(TriggerBuffEvent triggerBuffEvent, TriggerBuffEventArgs triggerBuffEventArgs)
    {
        buffEvent?.Invoke(
            triggerBuffEventArgs.currentEnergy,
            triggerBuffEventArgs.currentRatio,
            triggerBuffEventArgs.currentTechnologyPoints
        );
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        BuffStore.instance.BuyBuff(buffData);
    }
}
