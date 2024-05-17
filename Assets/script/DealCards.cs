using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealCards : MonoBehaviour
{
    public GameObject CardPrefab;
    public GameObject CardPool;

    GetCard GetCard;
    List<GameObject> cards = new List<GameObject>();
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
        Clearpool();
        for (int i = 0; i < 5; i++) 
        {
            GameObject newCard = GameObject.Instantiate(CardPrefab, CardPool.transform);

            newCard.GetComponent<CardDisplay>().card = GetCard.RandomCard();

            cards.Add(newCard);
        }
    }

    public void Clearpool()
    {
        foreach (var card in  cards)
        {
            Destroy(card);
        }
        cards.Clear();
    }
}
