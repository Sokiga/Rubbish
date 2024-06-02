using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[Serializable]
public enum Rarity
{
    Normal,
    Advanced,
    Peak,
}

[RequireComponent(typeof(TriggerBuffEvent))]
public class Buff : MonoBehaviour
{
    public string buffName;
    public string describe;
    public int cost;
    public int sale;
    public Rarity rarity;

    public int energy;
    public int ratio;
    public int technologyPoints;
    public UnityEvent buffEvent;


    [HideInInspector] public TriggerBuffEvent triggerBuffEvent;
    Text UIBuffName;
    Text UIDescribe;
    Text UICost;
    Text UIRarity;

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
        buffEvent?.Invoke();
    }
}
