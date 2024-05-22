using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardDisplay : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    //文本显示
    public Text CardClass;
    public Text CardPoint;
    public Text CardMarks;
    public bool isSelected;
    public int Id;

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

        Id = card.Id;
        CardPoint.text = card.Value.ToString();
        CardMarks.text = card.Score.ToString();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("OnPinterClick" + eventData.ToString());
        if (CardManager.instance.DeleteMode)
        {
            isSelected = !isSelected;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("exit");
    }
}
