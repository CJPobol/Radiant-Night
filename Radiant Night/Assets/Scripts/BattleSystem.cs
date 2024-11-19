using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
    IAttackable[] enemySkillSet = { null, null, null, null, null };

    Unit currentUnit;
    IAttackable currentSkillSet;

    void UpdateHealthbars()
    {
        for (int i = 0; i < playerUnits.Length; i++)
        {
            if (playerUnits[i] == null) continue;
            playerUnits[i].healthbar.GetComponent<Slider>().value = (playerUnits[i].currentHP * 100) / playerUnits[i].maxHP;
        }
        for (int i = 0; i < enemyUnits.Length; i++)
        {
            if (enemyUnits[i] == null) continue;
            enemyUnits[i].healthbar.GetComponent<Slider>().value = (enemyUnits[i].currentHP * 100) / enemyUnits[i].maxHP;
        }
    }

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
            enemySkillSet[i] = enemy[i].GetComponent<IAttackable>();
        }

        NextInOrder();
    }

    void NextInOrder()
    {
        UpdateHealthbars();
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
        //      NOTE: if a player and an enemy have the same order value, player goes first. If two players
        //      have the same order, the player that came first in the array is chosen, meaning the one
        //      the user selected on the character select screen first.

        Unit nextPlayer = playerUnits[0];
        Unit nextEnemy = enemyUnits[0];
        IAttackable PnextSkillSet = playerSkillSet[0];
        IAttackable EnextSkillSet = enemySkillSet[0];
        for (int i = 1; i < 5; i++)
        {
            if (playerUnits[i] == null) continue;
            if (playerUnits[i].order > nextPlayer.order)
            {
                nextPlayer = playerUnits[i];
                PnextSkillSet = playerSkillSet[i];
            }
        }
        for (int i = 1; i < 5; i++)
        {
            if (enemyUnits[i] == null) continue;
            if (enemyUnits[i].order > nextEnemy.order)
            {
                nextEnemy = enemyUnits[i];
                EnextSkillSet = enemySkillSet[i];
            }
        }
        if (nextPlayer.order >= nextEnemy.order)
        {
            state = battleState.PLAYERTURN;
            currentUnit = nextPlayer;
            currentSkillSet = PnextSkillSet;
        }
        else if (nextPlayer.order < nextEnemy.order)
        {
            state = battleState.ENEMYTURN;
            currentUnit = nextEnemy;
            currentSkillSet = EnextSkillSet;
            StartCoroutine(EnemyAction());
        }
        
        namePanel.text = currentUnit.unitName; 
    }

    public IEnumerator EnemyAction()
    {
        if (state != battleState.ENEMYTURN)
        {
            yield break;
        }
        currentSkillSet.BasicAtk(currentUnit, playerUnits, enemyUnits);
        currentUnit.order = 0;
        yield return new WaitForSeconds(2f);
        NextInOrder();
    }
    
    public void OnBasicAtk()
    {
        if (state != battleState.PLAYERTURN)
        {
            return;
        }
        currentSkillSet.BasicAtk(currentUnit, playerUnits, enemyUnits);
        currentUnit.order = 0;
        NextInOrder();
    }
    public void OnSpecialAtk1()
    {
        if (state != battleState.PLAYERTURN)
        {
            return;
        }
        currentSkillSet.SpecialAtk1(currentUnit, playerUnits, enemyUnits);
        currentUnit.order = 0;
        NextInOrder();
    }

    public void OnSpecialAtk2()
    {
        if (state != battleState.PLAYERTURN)
        {
            return;
        }
        currentSkillSet.SpecialAtk2(currentUnit, playerUnits, enemyUnits);
        currentUnit.order = 0;
        NextInOrder();
    }
}
