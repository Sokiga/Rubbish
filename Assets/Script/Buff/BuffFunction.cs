using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffFunction : MonoBehaviour
{
    Buff buff;

    private void Awake()
    {
        buff = GetComponent<Buff>();
    }

    public void EnergyConservation_1(int currentEnergy, int currentRatio, int currentTechnologyPoints)
    {
        foreach (Card card in CardManager.instance.handCardDeck)
        {
            if (card.cardData.value > 10)
            {
                currentEnergy += buff.energy;
            }
        }
    }

    public void EnergyConservation_2(int currentEnergy, int currentRatio, int currentTechnologyPoints)
    {
        foreach (Card card in CardManager.instance.handCardDeck)
        {
            if (card.cardData.value > 5 && card.cardData.value < 11)
            {
                currentEnergy += buff.energy;
            }
        }
    }

    public void EnergyConservation_3(int currentEnergy, int currentRatio, int currentTechnologyPoints)
    {
        foreach (Card card in CardManager.instance.handCardDeck)
        {
            if (card.cardData.value > 0 && card.cardData.value < 6)
            {
                currentEnergy += buff.energy;
            }
        }
    }

    public void AdaptingToLocalConditions_1(int currentEnergy, int currentRatio, int currentTechnologyPoints)
    {
        if (ScoreManager.instance.niu == 0 || ScoreManager.instance.niu >= 6 && ScoreManager.instance.niu <= 9)
        {
            currentRatio += buff.ratio;
        }
    }

    public void AdaptingToLocalConditions_2(int currentEnergy, int currentRatio, int currentTechnologyPoints)
    {
        if (ScoreManager.instance.niu >= 1 && ScoreManager.instance.niu <= 5)
        {
            currentRatio += buff.ratio;
        }
    }

    public void GreenManufacturing(int currentEnergy, int currentRatio, int currentTechnologyPoints)
    {
        foreach (Card card in CardManager.instance.handCardDeck)
        {
            if (card.cardData.suit == Suit.Electronic)
            {
                currentRatio += buff.ratio;
            }
        }
    }

    public void Biodegradable(int currentEnergy, int currentRatio, int currentTechnologyPoints)
    {
        foreach (Card card in CardManager.instance.handCardDeck)
        {
            if (card.cardData.suit == Suit.Biological)
            {
                currentRatio += buff.ratio;
            }
        }
    }

    public void GreenWaterAndGreenMountains(int currentEnergy, int currentRatio, int currentTechnologyPoints)
    {
        foreach (Card card in CardManager.instance.handCardDeck)
        {
            if (card.cardData.suit == Suit.Foundational)
            {
                currentRatio += buff.ratio;
            }
        }
    }

    public void SpecialTransformation_1(int currentEnergy, int currentRatio, int currentTechnologyPoints)
    {
        foreach (Card card in CardManager.instance.handCardDeck)
        {
            if (card.cardData.suit == Suit.Electronic)
            {
                currentEnergy += buff.energy;
            }
        }
    }

    public void SpecialTransformation_2(int currentEnergy, int currentRatio, int currentTechnologyPoints)
    {
        foreach (Card card in CardManager.instance.handCardDeck)
        {
            if (card.cardData.suit == Suit.Biological)
            {
                currentEnergy += buff.energy;
            }
        }
    }

    public void SpecialTransformation_3(int currentEnergy, int currentRatio, int currentTechnologyPoints)
    {
        foreach (Card card in CardManager.instance.handCardDeck)
        {
            if (card.cardData.suit == Suit.Foundational)
            {
                currentEnergy += buff.energy;
            }
        }
    }

    public void QualityEducation(int currentEnergy, int currentRatio, int currentTechnologyPoints)
    {
        currentTechnologyPoints += buff.technologyPoints;
    }

    public void IntegratedSystems(int currentEnergy, int currentRatio, int currentTechnologyPoints)
    {
        for (int i = 0; i < CardManager.instance.playTimes; i++)
        {
            currentRatio += buff.ratio;
        }
    }

    public void FineManagement(int currentEnergy, int currentRatio, int currentTechnologyPoints)
    {
        for (int i = 0; i < CardManager.instance.discardTimes; i++)
        {
            currentRatio += buff.ratio;
        }
    }

    public void Intelligent(int currentEnergy, int currentRatio, int currentTechnologyPoints)
    {
        for (int i = 0; i < CardManager.instance.playTimes; i++)
        {
            currentTechnologyPoints += buff.technologyPoints;
        }
    }

    public void LowCarbonTechnology(int currentEnergy, int currentRatio, int currentTechnologyPoints)
    {
        for (int i = 0; i < CardManager.instance.discardTimes; i++)
        {
            currentTechnologyPoints += buff.technologyPoints;
        }
    }

    public void IndustrialRevolution(int currentEnergy, int currentRatio, int currentTechnologyPoints)
    {
        currentTechnologyPoints += buff.technologyPoints;
    }

    public void NewBatteries(int currentEnergy, int currentRatio, int currentTechnologyPoints)
    {
        currentRatio += buff.ratio;
    }

    public void QuantitativeChange_1(int currentEnergy, int currentRatio, int currentTechnologyPoints)
    {

    }

    public void QuantitativeChange_2(int currentEnergy, int currentRatio, int currentTechnologyPoints)
    {

    }

}
