// 花色类 点数类 积分类 
    public class Card
{
    public string CardClass;
    public int id;
    //构造函数
    public Card(string _CardClass,int _id)
    {
        this.CardClass = _CardClass;
        this.id = _id;
    }
}
    //电子类
    public class Electronic: Card
{
    //点数、积分
    public int CardPoint;
    public int CardMarks;
    public Electronic(string _CardClass,int _id, int _CardPoint, int _CardMarks): base(_CardClass,_id)
    { 
        this.CardPoint = _CardPoint;
        this.CardMarks = _CardMarks;
    }

}
    //生物类
    public class Biological: Card
{
    //点数、积分
    public int CardPoint;
    public int CardMarks;
    public Biological(string _CardClass,int _id, int _CardPoint, int _CardMarks): base(_CardClass,_id)
    {
        this.CardPoint = _CardPoint;
        this.CardMarks = _CardMarks;
    }

}
    //基础类
    public class Foundational : Card
{
    //点数、积分
    public int CardPoint;
    public int CardMarks;
    public Foundational(string _CardClass,int _id, int _CardPoint, int _CardMarks): base(_CardClass,_id)
    {
        this.CardPoint = _CardPoint;
        this.CardMarks = _CardMarks;
    }

}