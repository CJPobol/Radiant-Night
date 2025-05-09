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

public struct enemy 
{
    Sprite model;
    Transform station;
    IAttackable skillset;
    Unit unit;


}


public class BattleSystem : MonoBehaviour
{
    private static BattleSystem instance;

    public GameObject combatSystem;

    [HideInInspector] public battleState state;


    public GameObject characterSelector;
    public TextMeshProUGUI namePanel, infoboard;
    public Button atk1;

    GameObject[] playerCharacter = { null, null, null, null, null };
    public GameObject[] playerSelectors;
    public Transform[] playerStation;

    private GameObject[] enemy = { null, null, null, null, null };

    public GameObject[] enemySelectors;
    public Transform[] enemyStation;

    public GameObject AshleyPrefab;
    public GameObject CharliePrefab;

    Unit captain = null;

    Unit[] playerUnits = { null, null, null, null, null };
    IAttackable[] playerSkillSet = { null, null, null, null, null };
    Animator[] playerAnimators = { null, null, null, null, null };
    Unit[] enemyUnits = { null, null, null, null, null };
    IAttackable[] enemySkillSet = { null, null, null, null, null };
    Animator[] enemyAnimators = { null, null, null, null, null };

    Unit currentUnit;
    IAttackable currentSkillSet;
    Animator currentAnimator;

    [HideInInspector] public bool isSelectingAllyUnit = false;
    [HideInInspector] public bool isSelectingEnemyUnit = false;

    [HideInInspector] public Unit selectedAlly = null;
    [HideInInspector] public Unit selectedEnemy = null;

    [HideInInspector] public bool turnActive;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one BattleSystem.");
        }

        instance = this;
        combatSystem.gameObject.SetActive(false);
    }

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
    public static BattleSystem GetInstance()
    {
        return instance;
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

    public void InitializeEnemies(GameObject[] enemies)
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] == null) continue;
            Debug.Log(enemy[i] + " " + enemies[i]);
            enemy[i] = enemies[i];
            enemyUnits[i] = Instantiate(enemies[i], enemyStation[i]).GetComponent<Unit>();
            enemySkillSet[i] = enemies[i].GetComponent<IAttackable>();
            enemyAnimators[i] = enemies[i].GetComponentInChildren<Animator>();
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

    public void OnSelection(GameObject characterStation)
    {
        Unit tempunit = characterStation.GetComponentInChildren<Unit>();
        if (tempunit.friendly) 
        {
            selectedAlly = tempunit;
        }
        else
        {
            selectedEnemy = tempunit;
        }
    }

    public void SetupBattle()
    {
        state = battleState.START;

        for (int i = 0; i < 5; i++)
        {
            if (playerCharacter[i] != null) 
            {
                playerUnits[i] = playerCharacter[i].GetComponent<Unit>();
                playerSkillSet[i] = playerCharacter[i].GetComponent<IAttackable>();
                playerAnimators[i] = playerCharacter[i].GetComponentInChildren<Animator>();
            }
        }

        //TODO: APPLY GIFT EFFECT BASED ON CAPTAIN


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
        Animator PnextAnim = playerAnimators[0];
        Animator EnextAnim = enemyAnimators[0];
        for (int i = 1; i < playerUnits.Length; i++)
        {
            if (playerUnits[i] == null) continue;
            if (playerUnits[i].order > nextPlayer.order)
            {
                nextPlayer = playerUnits[i];
                PnextSkillSet = playerSkillSet[i];
                PnextAnim = playerAnimators[i];
            }
        }
        for (int i = 1; i < enemyUnits.Length; i++)
        {
            if (enemyUnits[i] == null) continue;
            if (enemyUnits[i].order > nextEnemy.order)
            {
                nextEnemy = enemyUnits[i];
                EnextSkillSet = enemySkillSet[i];
                EnextAnim = enemyAnimators[i];
            }
        }
        if (nextPlayer.order >= nextEnemy.order)
        {
            state = battleState.PLAYERTURN;
            currentUnit = nextPlayer;
            currentSkillSet = PnextSkillSet;
            currentAnimator = PnextAnim;
        }
        else if (nextPlayer.order < nextEnemy.order)
        {
            state = battleState.ENEMYTURN;
            currentUnit = nextEnemy;
            currentSkillSet = EnextSkillSet;
            currentAnimator = EnextAnim;
            StartCoroutine(EnemyAction());
        }
        
        namePanel.text = currentUnit.unitName;
        infoboard.text = 
            "Health: " + currentUnit.currentHP + "/" + currentUnit.maxHP +
            "\nOrder: " + currentUnit.order + 
            "\nA2 Charge: " + currentUnit.A2Charge*100 + "%";
        
        if (currentUnit.cooldown > 0)
        {
            UITools.DisableButton(atk1);
        }
        else
        {
            UITools.EnableButton(atk1);
        }
    }

    public IEnumerator EnemyAction()
    {
        yield return new WaitForSeconds(1f);
        if (state != battleState.ENEMYTURN)
        {
            yield break;
        }
        currentSkillSet.BasicAtk(currentUnit, playerUnits, enemyUnits);
        currentUnit.order = 0;
        currentAnimator.SetTrigger("onAttack");
        yield return new WaitForSeconds(1f);
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
        currentAnimator.SetTrigger("onAttack");
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
        currentAnimator.SetTrigger("onAttack");
        currentSkillSet.SpecialAtk1(currentUnit, playerUnits, enemyUnits);
        //NOTE: immediately goes back to NextInOrder with this function call ^
    }

    public void OnSpecialAtk2()
    {
        if (state != battleState.PLAYERTURN)
        {
            return;
        }
        currentAnimator.SetTrigger("onAttack");
        currentSkillSet.SpecialAtk2(currentUnit, playerUnits, enemyUnits);
        //NOTE: immediately goes back to NextInOrder with this function call ^
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
}
