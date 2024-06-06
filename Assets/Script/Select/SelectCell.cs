using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectCell : MonoBehaviour, IPointerClickHandler
{
    public int targetScore;
    public Text UITargetScore;

    private void Awake()
    {
        UITargetScore = GetComponentInChildren<Text>();
    }

    private void Start()
    {
        UITargetScore.text = targetScore.ToString();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ScoreManager.instance.SetTargetEnergy(targetScore);
        UIManager.Instance.ConversionGamePanel();
    }
}
