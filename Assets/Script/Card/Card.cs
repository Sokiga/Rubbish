using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Events;
using System.Collections.Generic;

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
    public Sprite Biological;
    public Sprite Foundational;
    public Sprite Electronic;
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
    Sprite background;

    public CardData cardData;
    public bool isSelected;

    


    private void Awake()
    {
        suitText = transform.Find("suit").GetComponent<Text>();
        valueText = transform.Find("value").GetComponent<Text>();
        energyText = transform.Find("energy").GetComponent<Text>();
        background = transform.Find("background").GetComponent<Image>().sprite;
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
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        isSelected = !isSelected;
    }
    public void UpdateBackground()
    {
        string suitTextString = suitText.text;
        if (suitTextString == "Biological")
        {
            transform.Find("background").GetComponent<Image>().sprite = cardData.Biological;
        }
        else if (suitTextString == "Foundational")
        {
            transform.Find("background").GetComponent<Image>().sprite = cardData.Foundational;
        }
        else if (suitTextString == "Electronic")
        {
            transform.Find("background").GetComponent<Image>().sprite = cardData.Electronic;
        }
        else
        {
            Debug.LogError("Unknown suit: " + suitTextString);
        }
    }
}

    