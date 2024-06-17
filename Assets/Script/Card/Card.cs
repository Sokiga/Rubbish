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

    Sprite Biological;
    Sprite Foundational;
    Sprite Electronic;

    public CardData cardData;
    public bool isSelected;

    


    private void Awake()
    {
        suitText = transform.Find("suit").GetComponent<Text>();
        valueText = transform.Find("value").GetComponent<Text>();
        energyText = transform.Find("energy").GetComponent<Text>();
        //background = transform.Find("background").GetComponent<Image>().sprite;
    }

    [Obsolete]
    private void Start()
    {
        suitText.text = cardData.suit.ToString();
        valueText.text = cardData.value.ToString();
        energyText.text = cardData.energy.ToString();
        UpdateBackground(); // 确保背景根据花色更新
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
        switch (cardData.suit)
        {
            case Suit.Biological:
                transform.Find("background").GetComponent<Image>().sprite = cardData.Biological;
                break;
            case Suit.Foundational:
                transform.Find("background").GetComponent<Image>().sprite = cardData.Foundational;
                break;
            case Suit.Electronic:
                transform.Find("background").GetComponent<Image>().sprite = cardData.Electronic;
                break;
            default:
                Debug.LogError("Unknown suit type.");
                break;
        }

        // 更新卡牌的背景
        if (background != null)
        {
            transform.Find("background").GetComponent<Image>().sprite = background;
        }
        else
        {
            Debug.LogError("Background sprite not found for suit: " + cardData.suit);
        }
    }

}

    