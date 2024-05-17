using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCard : MonoBehaviour
{
    //存储链表
    public TextAsset CardData;
    public List<Card> CardList = new List<Card>();
    void Start()
    {
        LoadCardData();
        TestLoad();
    }

    void Update()
    {
        
    }
    public void LoadCardData() 
    {
        //读取链表，逗号分割
        string[] datarow = CardData.text.Split('\n');
        foreach (var row in datarow) 
        {
            string[] rowArray = row.Split(',');
            if (rowArray[0] == "#") 
            {
                continue;
            }
            else if (rowArray[0] == "Electronic")
            {
                //建立电子类
                string CardClass = rowArray[1];
                int id = int.Parse(rowArray[2]);
                int Point = int.Parse(rowArray[3]);
                int Marks = int.Parse(rowArray[4]);
                Electronic electronic = new Electronic(CardClass,id, Point, Marks);
                CardList.Add(electronic);

                //Debug.Log("检测到电子类垃圾："+ electronic.CardClass);
            }
            else if (rowArray[0] == "Biological")
            {
                //建立生物类
                string CardClass = rowArray[1];
                int id = int.Parse(rowArray[2]);
                int Point = int.Parse(rowArray[3]);
                int Marks = int.Parse(rowArray[4]);
                Biological biological = new Biological(CardClass,id, Point, Marks);
                CardList.Add(biological);

                //Debug.Log("检测到生物类垃圾：" + biological.CardClass);
            }
            else if (rowArray[0] == "Foundational")
            {
                //建立基础类
                string CardClass = rowArray[1];
                int id = int.Parse(rowArray[2]);
                int Point = int.Parse(rowArray[3]);
                int Marks = int.Parse(rowArray[4]);
                Foundational foundational = new Foundational(CardClass,id, Point, Marks);
                CardList.Add(foundational);

                //Debug.Log("检测到基础类垃圾：" + foundational.CardClass);
            }
        }
    }

    public void TestLoad()
    {
        foreach (var item in CardList) 
        {
            Debug.Log("识别垃圾：" + item.id.ToString() + item.CardClass);        
        }
    }

    public Card RandomCard() 
    {
        Card card = CardList[Random.Range(0,CardList.Count)];
        return card;
    }
}
