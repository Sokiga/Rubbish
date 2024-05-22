using System;

//定义卡牌
public enum Suit
{
    Electronic,
    Biological,
    Foundational
}

[Serializable]
public class Card
{
    public Suit Suit;
    public int Value;
    public int Score;
}