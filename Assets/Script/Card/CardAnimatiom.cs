using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class CardAnimatiom : MonoBehaviour
{
    [SerializeField] private Transform[] playCards;

    [SerializeField] private int vib = 0;
    [SerializeField] private float elastic = 0.0f;

    [SerializeField] private Text damageText;

    public float OutExpo { get; private set; }

    public void PlayCards()
    {
        for (int i = 0;i < playCards.Length;i++)
        {
            playCards[i].DOMove(new Vector3(4 * (i - 1), 0f, 0f), 0.5f).SetEase(Ease.OutExpo).SetDelay(0.2f * i);
        }
    }
}
