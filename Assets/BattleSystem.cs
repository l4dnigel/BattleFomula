using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    private bool enemyTurn = false;
    private Player player;
    private Monster monster;

    void Start()
    {
        //Player player = new Player("克蘇魯", 50, 10, 5, 3);
        //Monster monster = new Monster("派大星", 30, 6, 10, 5);
        player = new Player("克蘇魯", 50, 9, 5, 3);
        monster = new Monster("派大星", 46, 8, 7, 5);
        LegendMonster lMonster = new LegendMonster("巨神兵", 100, 20, 10, 1);
        Debug.Log(monster.Hi() + monster.CatchState());
        Debug.Log(lMonster.Hi() + lMonster.CatchState());
        Debug.Log("............" + player.Hi() + " 準備戰鬥！");

        BattleFormula bf = new BattleFormula();
        if (bf.playerFirstHand(player, monster))
        {
            enemyTurn = true;
            bf.Attack(player, monster);
        }
        else
        {
            enemyTurn = false;
            bf.Attack(monster, player);
            //Debug.Log(player.name + " 的 Hp : " + player.hp + monster.name + " 的 Hp : " + monster.hp);
        }

        InvokeRepeating("NextRound", 0, 1);
    }

    private void NextRound()
    {
        BattleFormula bf = new BattleFormula();
        if (enemyTurn == false)
        {
            enemyTurn = true;
            bf.Attack(player, monster);
            //Debug.Log(player.name + " 的 Hp : " + player.hp + monster.name + " 的 Hp : " + monster.hp);

            if (monster.Live() == false)
            {
                Debug.LogWarning(player.name + " 獲勝了！");
                CancelInvoke();
            }
        }
        else
        {
            enemyTurn = false;
            bf.Attack(monster, player);
            //Debug.Log(player.name + " 的 Hp : " + player.hp + monster.name + " 的 Hp : " + monster.hp);

            if (player.Live() == false)
            {
                Debug.LogWarning(monster.name + " 獲勝了！");
                CancelInvoke();
            }
        }
    }
}
