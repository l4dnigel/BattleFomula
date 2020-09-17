using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillData
{
    public string skillName = "";//技能名稱
    public int useTime = 0;//使用次數
    public int skillPower = 0;//技能本身威力
    public int atkBuff = 0;//攻擊力屬性加成

    public SkillData(string name, int use, int power, int buff)
    {
        this.skillName = name;
        this.useTime = use;
        this.skillPower = power;
        this.atkBuff = buff;
    }
}

public class BattleFormula
{
    public bool playerFirstHand(BaseAttribute player, BaseAttribute monster)
    {
        // 大於跟大於等於涵義有差，這邊的規則是若速度一樣給玩家先動。
        if (player.speed >= monster.speed)
        {
            return true;
        }

        return false;
    }

    public void Attack(BaseAttribute source, BaseAttribute target, SkillData skill = null)
    {
        if (skill == null)
        {
            skill = new SkillData("地球上投", 3, 10, 5);
        }

        // 傷害公式：攻擊者的攻擊力 30% * 技能的攻擊加成後四捨五入的值 加上 技能本身攻擊力 70% 四捨五入後的值 減去 目標的防禦力  
        int damage = Mathf.RoundToInt(source.atk * 0.3f) * (skill.atkBuff) + Mathf.RoundToInt(skill.skillPower * 0.7f) - target.def;
        // 若傷害小於等於0，小於是有可能的，當今天遇到高防怪時就會出現
        if (damage <= 0)
        {
            // 最少傷害有 1 滴規則
            damage = 1;
        }
        target.hp -= damage;

        Debug.Log(source.name + "( " + source.hp + " )" + " 使用了 : " + skill.skillName + "!!!\n" + target.name + " 的 Hp : " + target.hp);
    }
}