using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Events;
using System.Collections.Generic;
using System.Text.RegularExpressions;

[Serializable]
public enum Suit
{
    Biological,
    Foundational,
    Electronic,
}

[Serializable]
public struct CardData
{
    public int id;
    public Suit suit;
    public int value;
    public int energy;
    public Sprite background;
    public Image image;
}

public static class ExtensionMethods
{

    public static float Remap(this float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }

}

public class Card : MonoBehaviour, IPointerClickHandler
{
    Text suitText;
    Text valueText;
    Text energyText;
    public Image background;

    public CardData cardData;
    public bool isSelected;

    


    private void Awake()
    {
        suitText = transform.Find("suit").GetComponent<Text>();
        valueText = transform.Find("value").GetComponent<Text>();
        energyText = transform.Find("energy").GetComponent<Text>();
    }

    [Obsolete]
    private void Start()
    {
        suitText.text = cardData.suit.ToString();
        valueText.text = cardData.value.ToString();
        energyText.text = cardData.energy.ToString();
    }

    public void InitCard(CardData cardData)
    {
        this.cardData = cardData;
        MatchBackGround();
    }

    private void MatchBackGround()
    {
        switch (cardData.suit)
        {
            case Suit.Electronic:
                background.sprite = GameResources.Instance.Electronic;
                break;
            case Suit.Foundational:
                background.sprite = GameResources.Instance.Foundational;
                break;
            case Suit.Biological:
                background.sprite = GameResources.Instance.Biological;
                break;
            default:
                break;            
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        isSelected = !isSelected;
    }
}

    