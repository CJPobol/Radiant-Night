using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.UI.CanvasScaler;

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
    [SerializeField] private GameObject combatSystem;

    [HideInInspector] public battleState state;
    public GameObject characterSelector;
    public TextMeshProUGUI namePanel;

    GameObject[] playerCharacter = { null, null, null, null, null };
    public GameObject[] playerSelectors;
    public Transform[] playerStation;

    //TEMP HARDCODED ENEMY ARRAY
    public GameObject[] enemy;

    public GameObject[] enemySelectors;
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

    [HideInInspector] public bool isSelectingAllyUnit = false;
    [HideInInspector] public bool isSelectingEnemyUnit = false;

    [HideInInspector] public Unit selectedUnit = null;

    [HideInInspector] public bool turnActive;

    private void Start()
    {
        for (int i = 0; i < enemySelectors.Length; i++)
        {
            enemySelectors[i].SetActive(false);
        }
        for (int i = 0; i < playerSelectors.Length; i++)
        {
            playerSelectors[i].SetActive(false);
        }
        
    }

    void UpdateHealthbars()
    {
        for (int i = 0; i < playerUnits.Length; i++)
        {
            if (playerUnits[i] == null) continue;
            playerUnits[i].healthbar.GetComponent<Slider>().value = (playerUnits[i].currentHP * 100) / playerUnits[i].maxHP;
            if (playerUnits[i].currentHP <= 0)
            {
                playerUnits[i].isDead = true;
                playerUnits[i].order = 0;
                CheckWinLoss();
            }
        }
        for (int i = 0; i < enemyUnits.Length; i++)
        {
            if (enemyUnits[i] == null) continue;
            enemyUnits[i].healthbar.GetComponent<Slider>().value = (enemyUnits[i].currentHP * 100) / enemyUnits[i].maxHP;
            if (enemyUnits[i].currentHP <= 0)
            {
                enemyUnits[i].isDead = true;
                Debug.Log("you killed an enemy!");
                enemyUnits[i].order = 0;
                CheckWinLoss();
            }
        }
    }

    void CheckWinLoss()
    {
        for (int i = 0; i < 5; i++)
        {
            if (playerUnits[i] != null && !playerUnits[i].isDead)
                break;
            state = battleState.LOSE;
            EndBattle();
        }
        for (int i = 0; i < 5; i++)
        {
            if (enemyUnits[i] != null && !enemyUnits[i].isDead)
                break;
            state = battleState.WIN;
            EndBattle();
        }
    }

    void EndBattle()
    {
        if (state == battleState.WIN)
        {
            Debug.Log("You Win!");
        }
        if (state == battleState.LOSE)
        {
            Debug.Log("You Lose.");
        }
        combatSystem.gameObject.SetActive(false);
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

    public void OnSelection(GameObject characterStation)
    {
        selectedUnit = characterStation.GetComponentInChildren<Unit>();
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
        for (int i = 0; i < enemy.Length; i++)
        {
            if (enemy[i] != null)
            {
                enemyUnits[i] = Instantiate(enemy[i], enemyStation[i]).GetComponent<Unit>();
                enemySkillSet[i] = enemy[i].GetComponent<IAttackable>();
            }
                
        }

        NextInOrder();
    }

    public void NextInOrder()
    {
        UpdateHealthbars();
        //advance order
        for (int i = 0; i < 5; i++)
        {
            if (playerUnits[i] != null && !playerUnits[i].isDead) 
                playerUnits[i].order += playerUnits[i].speed / 100;
        }
        for (int i = 0; i < 5; i++)
        {
            if (enemyUnits[i] != null && !enemyUnits[i].isDead)
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
        for (int i = 1; i < playerUnits.Length; i++)
        {
            if (playerUnits[i] == null) continue;
            if (playerUnits[i].order > nextPlayer.order)
            {
                nextPlayer = playerUnits[i];
                PnextSkillSet = playerSkillSet[i];
            }
        }
        for (int i = 1; i < enemyUnits.Length; i++)
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
        turnActive = true;
        currentUnit.cooldown -= 1;
        currentSkillSet.BasicAtk(currentUnit, playerUnits, enemyUnits);
        //NOTE: immediately goes back to NextInOrder with this function call ^
    }
    public void OnSpecialAtk1()
    {
        if (state != battleState.PLAYERTURN)
        {
            return;
        }
        if (currentUnit.cooldown > 0)
        {
            return;
        }
        turnActive = true;
        currentSkillSet.SpecialAtk1(currentUnit, playerUnits, enemyUnits);
        //NOTE: immediately goes back to NextInOrder with this function call ^
    }

    public void OnSpecialAtk2()
    {
        if (state != battleState.PLAYERTURN)
        {
            return;
        }
        currentSkillSet.SpecialAtk2(currentUnit, playerUnits, enemyUnits);
        //NOTE: immediately goes back to NextInOrder with this function call ^
    }
}
