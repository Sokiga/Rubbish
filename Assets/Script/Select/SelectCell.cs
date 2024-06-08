using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectCell : MonoBehaviour, IPointerClickHandler
{
    public int targetScore;
    public int technologyPoint;
    private Text UITargetScore;
    private Text UITechnologyPoint;

    private void Awake()
    {
        UITargetScore = transform.Find("TargetScore").GetComponent<Text>();
        UITechnologyPoint = transform.Find("TechnologyPoint").GetComponent<Text>();
    }

    public void Init(SelectCellData selectCellData)
    {
        targetScore = selectCellData.targetScore;
        UITargetScore.text = targetScore.ToString();
        technologyPoint = selectCellData.technologyPoint;
        UITechnologyPoint.text = technologyPoint.ToString();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ScoreManager.instance.SetTargetEnergy(targetScore);
        ScoreManager.instance.getTechnologyPoint = technologyPoint;
        UIManager.Instance.ConversionGamePanel();
        CardManager.instance.InitializeDeck(CardManager.instance.cardData);
        CardManager.instance.DealCard();
        SelectedPanel.Instance.RemoveAll();
    }
}
