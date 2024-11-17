using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;

public enum battleState 
{
    START,
    PLAYERTURN,
    ENEMYTURN,
    WIN,
    LOSE
}

public class BattleSystem : MonoBehaviour
{
    public battleState state;

    public GameObject player;
    public GameObject enemy;

    public Transform playerStation;
    public Transform enemyStation;

    Ashley playerUnit;
    Unit enemyUnit;

    public TextMeshProUGUI namePanel;

    

    // Start is called before the first frame update
    void Start()
    {
        state = battleState.START;
        SetupBattle();
    }

    void SetupBattle()
    {
        GameObject playerStart = Instantiate(player, playerStation);
        playerUnit = playerStart.GetComponent<Ashley>();
        playerUnit.order = 0;

        GameObject enemyStart = Instantiate(enemy, enemyStation);
        enemyUnit = enemyStart.GetComponent<Unit>();
        enemyUnit.order = 0;

        NextInOrder();
        
    }

    void NextInOrder()
    {
        //TODO: make this work with more than 1 ally and 1 enemy.

        playerUnit.order += (float)playerUnit.speed / 100;
        enemyUnit.order += (float)enemyUnit.speed / 100;

        if (playerUnit.order > enemyUnit.order)
        {
            state = battleState.PLAYERTURN;
            PlayerTurn();
        }
        else if (enemyUnit.order > playerUnit.order)
        {
            state = battleState.ENEMYTURN;
            EnemyTurn();
        }
        else
        {
            Debug.LogError("Player and Enemy have the same speed, what do we do??");
        }
    }

    void PlayerTurn()
    {
        namePanel.text = playerUnit.unitName;
    }

    void EnemyTurn()
    {
        namePanel.text = enemyUnit.unitName;
    }

    public void OnBasicAtk()
    {
        if (state != battleState.PLAYERTURN)
        {
            return;
        }

        playerUnit.BasicAttack(enemyUnit);
        
        playerUnit.order = 0;
        NextInOrder();
    }



}
