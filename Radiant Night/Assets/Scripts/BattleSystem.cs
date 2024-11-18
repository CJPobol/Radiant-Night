using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
using JetBrains.Annotations;

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
    public GameObject characterSelector;
    public TextMeshProUGUI namePanel;

    GameObject[] playerCharacter = { null, null, null, null, null };
    public Transform[] playerStation;

    //TEMP HARDCODED ENEMY ARRAY
    public GameObject[] enemy;
    public Transform[] enemyStation;

    public GameObject AshleyPrefab;
    public GameObject CharliePrefab;

    Unit captain = null;

    Unit[] playerUnits = { null, null, null, null, null };
    IAttackable[] playerSkillSet = { null, null, null, null, null };
    Unit[] enemyUnits = { null, null, null, null, null };

    Unit currentUnit;
    IAttackable currentSkillSet;

    void InitializePlayer(GameObject character)
    {
        bool initialized = false;
        for (int i = 0; i < 5; i++)
        {
            if (playerCharacter[i] == null)
            {
                playerCharacter[i] = Instantiate(character, playerStation[i]);
                Debug.Log("Selected " + character.GetComponent<Unit>().unitName + " in slot " + i);
                initialized = true;
                break;
            }
            if (captain == null)
            {
                captain = playerCharacter[i].GetComponent<Unit>();
            }
        }
        if (!initialized)
            Debug.LogWarning("Team is full, character not selected.");
    }
    public void SelectAshley()
    {
        InitializePlayer(AshleyPrefab);
    }

    public void SelectCharlie()
    {
        InitializePlayer(CharliePrefab);
    }

    public void OnSubmit()
    {
        characterSelector.SetActive(false);

        SetupBattle();
    }

    public void SetupBattle()
    {
        state = battleState.START;

        for (int i = 0; i < 5; i++)
        {
            if (playerCharacter[i] != null) 
            {
                playerUnits[i] = playerCharacter[i].GetComponent<Unit>();
                Debug.Log(playerUnits[i].unitName);
                playerSkillSet[i] = playerCharacter[i].GetComponent<IAttackable>();
            }
        }

        //TODO: APPLY GIFT EFFECT BASED ON CAPTAIN


        //TEMPORARY HARD CODED ENEMIES
        for (int i = 0; i < 5; i++)
        {
            enemyUnits[i] = Instantiate(enemy[i], enemyStation[i]).GetComponent<Unit>();
        }

        NextInOrder();
    }

    void NextInOrder()
    {
        //advance order
        for (int i = 0; i < 5; i++)
        {
            if (playerUnits[i] != null) 
                playerUnits[i].order += playerUnits[i].speed / 100;
        }
        for (int i = 0; i < 5; i++)
        {
            if (enemyUnits[i] != null)
                enemyUnits[i].order += enemyUnits[i].speed / 100; 
        }

        //determine largest order value in either array
        Unit nextPlayer = playerUnits[0];
        Unit nextEnemy = enemyUnits[0];
        IAttackable nextSkillSet = playerSkillSet[0];
        for (int i = 1; i < 5; i++)
        {
            if (playerUnits[i] == null) continue;
            if (playerUnits[i].order > nextPlayer.order)
            {
                nextPlayer = playerUnits[i];
                nextSkillSet = playerSkillSet[i];
            }
        }
        for (int i = 1; i < 5; i++)
        {
            if (enemyUnits[i] == null) continue;
            if (enemyUnits[i].order > nextEnemy.order)
            {
                nextEnemy = enemyUnits[i];
            }
        }
        if (nextPlayer.order > nextEnemy.order)
        {
            state = battleState.PLAYERTURN;
            currentUnit = nextPlayer;
            currentSkillSet = nextSkillSet;
        }
        else
        {
            state = battleState.ENEMYTURN;
            currentUnit = nextEnemy;
        }

        namePanel.text = currentUnit.unitName; 
    }

    public void OnBasicAtk()
    {
        if (state != battleState.PLAYERTURN)
        {
            return;
        }
        currentSkillSet.BasicAtk();
        currentUnit.order = 0;
        NextInOrder();
    }
    public void OnSpecialAtk1()
    {
        if (state != battleState.PLAYERTURN)
        {
            return;
        }
        currentSkillSet.SpecialAtk1();
        currentUnit.order = 0;
        NextInOrder();
    }

    public void OnSpecialAtk2()
    {
        if (state != battleState.PLAYERTURN)
        {
            return;
        }
        currentSkillSet.SpecialAtk2();
        currentUnit.order = 0;
        NextInOrder();
    }
}
