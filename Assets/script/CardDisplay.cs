using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardDisplay : MonoBehaviour
{

    public TextMeshProUGUI CardClass;
    public TextMeshProUGUI CardPoint;
    public TextMeshProUGUI CardMarks;

    public Image Background;

    public Card card;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void ShowCard()
    {
        CardClass.text = card.CardClass;
        if (card is Electronic)
        {
            var Elec = card as Electronic;
            CardPoint.text = Elec.CardPoint.ToString();
            CardMarks.text = Elec.CardMarks.ToString();
        }
        else if (card is Biological)
        {
            var Biol = card as Biological;
            CardPoint.text = Biol.CardPoint.ToString();
            CardMarks.text = Biol.CardMarks.ToString();
        }
        else if (card is Foundational)
        {
            var Foun = card as Foundational;
            CardPoint.text = Foun.CardPoint.ToString();
            CardMarks.text = Foun.CardMarks.ToString();
        }
    }
}
