using System;

//定义卡牌
[System.Serializable]
public enum Suit
{
    Electronic,
    Biological,
    Foundational
}

[Serializable]
public class Card
{
    public int Id;
    public Suit Suit;
    public int Value;
    public int Score;

    public Card(int Id, Suit suit, int Value, int score)
    {
        this.Id = Id;
        this.Suit = suit;
        this.Value = Value;
        this.Score = score;
    }
}