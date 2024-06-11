using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Events;

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


}
