using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCards : MonoBehaviour
{
    public TextAsset CardData;
    public List<Card> CardList = new List<Card>();
    void Start()
    {
        LoadCardData();
    }

    void Update()
    {
        
    }
    public void LoadCardData() 
    {
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

                Debug.Log("检测到电子类垃圾："+ electronic.CardClass);
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

                Debug.Log("检测到生物类垃圾：" + biological.CardClass);
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

                Debug.Log("检测到基础类垃圾：" + foundational.CardClass);
            }
        }
    }
}
