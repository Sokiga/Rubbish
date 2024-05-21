using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using UnityEngine;

public class DealCards : MonoBehaviour
{
    public GameObject CardPrefab;
    public GameObject CardPool;

    GetCard GetCard;
    public int DiscardedCount = 0;
    public bool Selected = false;
    public List<GameObject> cards = new List<GameObject>();//手牌列表
    public List<GameObject> DiscardedCards = new List<GameObject>();//弃牌列表
    void Start()
    {
        GetCard = GetComponent<GetCard>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickDeal()
    {
        if (cards.Count == 0)
        {
            Clearpool();
            for (int i = 0; i < 5; i++)
            {
                //实例化新卡牌预制体
                GameObject newCard = GameObject.Instantiate(CardPrefab, CardPool.transform);
                //获取新卡牌的数据显示组件
                newCard.GetComponent<CardDisplay>().card = GetCard.RandomCard();

                cards.Add(newCard);
            }
        }
        else
        {
            for (int i = 0; i < DiscardedCount; i++)
            {
                GameObject newCard = GameObject.Instantiate(CardPrefab, CardPool.transform);

                newCard.GetComponent<CardDisplay>().card = GetCard.RandomCard();
                cards.RemoveAll(DiscardedCards.Contains);//移除手牌列表中所包含的弃牌列表元素
                cards.Add(newCard);//新抽取的卡牌加入手牌
            }
        }
    }
    public void OnClickSelect()
    {
        if (Selected = false)
        {
            DiscardedCount--;//取消选中
            Selected = true;
        }
        else
        {
            DiscardedCount++;//选中弃牌
            GameObject newDiscardedCards = GameObject.Instantiate(CardPrefab, CardPool.transform);
            DiscardedCards.Add(newDiscardedCards);
            Selected = false;
        }

        //弃牌数传给抽卡脚本
        DealCards dealCards = new DealCards();
        if (dealCards != null)
        {
            dealCards.DiscardedCards = DiscardedCards;
        }
    }
    public void Clearpool()
    {
        foreach (var card in cards)
        {
            Destroy(card);
        }
        cards.Clear();
    }
}
