using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAttribute
{
    public string name;//名字
    public int hp;//體力
    public int atk;//攻擊力
    public int def;//防禦力
    public int speed;//速度

    // 是否還活著
    public bool Live()
    {
        return hp > 0;
    }

    // 自報姓名
    public abstract string Hi();
}

public class Player : BaseAttribute
{
    public int mp;//魔力
    public Player(string name, int hp, int atk, int def, int speed)
    {
        this.name = name;
        this.hp = hp;
        this.atk = atk;
        this.def = def;
        this.speed = speed;
    }
    public override string Hi()
    {
        return "我是 " + name;
    }
}

public class Monster : BaseAttribute
{
    public Monster(string name, int hp, int atk, int def, int speed)
    {
        this.name = name;
        this.hp = hp;
        this.atk = atk;
        this.def = def;
        this.speed = speed;
    }
    public override string Hi()
    {
        return name + "登場了！！";
    }
    public virtual string CatchState()
    {
        return "可以收服";
    }
}

public class LegendMonster : Monster
{
    public LegendMonster(string name, int hp, int atk, int def, int speed) : base(name, hp, atk, def, speed)
    {

    }
    public override string Hi()
    {
        return "吼吼吼吼吼吼吼！" + name + "登場了！！";
    }
    public override string CatchState()
    {
        return "無法收服！";
    }
}
