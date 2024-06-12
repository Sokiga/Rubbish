using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems; // 如果你使用的是Unity的Event Trigger System  
using UnityEngine.UI;

public class DisCardAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    // 假设你有一个Image组件用于高亮和缩放  
    public Image buttonImage;


    // 初始颜色  
    private Color initialColor = new Color(245f / 255f, 77f / 255f, 64f / 255f, 1f);
    // 高亮颜色  
    private Color highlightColor = new Color(247f / 255f, 179f / 255f, 172f / 255f, 1f);
    // 按下颜色  
    private Color pressedColor = new Color(148f / 255f, 27f / 255f, 20f / 255f, 1f);

    // 初始缩放值  
    private Vector3 initialScale;

    // 在Start()中设置初始缩放值  
    void Start()
    {
        initialScale = buttonImage.rectTransform.localScale;

        
    }

    // 当鼠标移入按钮时  
    public void OnPointerEnter(PointerEventData eventData)
    {
        // 高亮并放大  
        buttonImage.color = highlightColor;
        buttonImage.rectTransform.DOScale(initialScale * 1.1f, 0.1f).SetEase(Ease.OutQuad);
    }

    // 当鼠标移出按钮时  
    public void OnPointerExit(PointerEventData eventData)
    {
        // 回到初始颜色和大小  
        buttonImage.color = initialColor;
        buttonImage.rectTransform.DOScale(initialScale, 0.1f).SetEase(Ease.InQuad);
    }

    // 当点击按钮时  
    public void OnPointerClick(PointerEventData eventData)
    {
        // 变暗并缩小，然后回到初始状态  
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(buttonImage.rectTransform.DOScale(initialScale * 0.8f, 0.08f).SetEase(Ease.InQuad));
        mySequence.AppendCallback(() => buttonImage.color = pressedColor);
        mySequence.Append(buttonImage.rectTransform.DOScale(initialScale, 0.08f).SetEase(Ease.OutQuad));
        mySequence.AppendCallback(() => buttonImage.color = initialColor); // 回到初始颜色  
    }
}