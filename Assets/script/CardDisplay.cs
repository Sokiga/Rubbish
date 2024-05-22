using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardDisplay : MonoBehaviour
{
    //文本显示
    public Text CardClass;
    public Text CardPoint;
    public Text CardMarks;
    public bool isSelected;

    

    public Image Background;

    public void InitData(Card card)
    {
        switch (card.Suit)
        {
            case Suit.Biological:
                CardClass.text = "Biological";
                break;
            case Suit.Foundational:
                CardClass.text = "Foundational";
                break;
            case Suit.Electronic:
                CardClass.text = "Electronic";
                break;
            default:
                break;
        }

        CardPoint.text = card.Value.ToString();
        CardMarks.text = card.Score.ToString();
    }

}
