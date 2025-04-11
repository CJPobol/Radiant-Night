using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Charlie : MonoBehaviour, IAttackable
{
    GameObject combatManager;
    BattleSystem battle;

    private void Start()
    {
        combatManager = GameObject.FindObjectOfType<BattleSystem>()?.gameObject;
        battle = combatManager.GetComponent<BattleSystem>();
    }

    public void BasicAtk(Unit self, Unit[] allies, Unit[] enemies)
    {
        Debug.Log("Charlie uses basic attack!");
        
        for (int i = 0; i < battle.enemySelectors.Length; i++)
        {
            battle.enemySelectors[i].SetActive(true);
        }
        StartCoroutine(HandleBasicAtk(self));
    }

    IEnumerator HandleBasicAtk(Unit self)
    {
        battle.isSelectingEnemyUnit = true;
        Debug.Log("Waiting for enemy selection...");
        yield return new WaitUntil(() => battle.selectedUnit != null);
        Debug.Log($"Selected Enemy {battle.selectedUnit.unitName}");
        Unit enemy = battle.selectedUnit;

        enemy.currentHP -= self.atk;
        battle.isSelectingEnemyUnit = false;
        battle.selectedUnit.Deselect();
        battle.selectedUnit = null;
        Debug.Log("Action complete! Ending Charlie's turn...");
        battle.turnActive = false;
        self.order = 0;
        for (int i = 0; i < battle.enemySelectors.Length; i++)
        {
            battle.enemySelectors[i].SetActive(false);
        }
        battle.NextInOrder();
    }

    public void SpecialAtk1(Unit self, Unit[] allies, Unit[] enemies)
    {
        Debug.Log("Charlie uses special attack 1!");
        for (int i = 0; i < battle.playerSelectors.Length; i++)
        {
            battle.playerSelectors[i].SetActive(true);
        }
        StartCoroutine(HandleSpAtk1(self));
    }

    IEnumerator HandleSpAtk1(Unit self)
    {
        self.order = 0;
        battle.isSelectingAllyUnit = true;
        Debug.Log("Waiting for ally selection...");
        yield return new WaitUntil(() => battle.selectedUnit != null);

        Debug.Log($"Selected {battle.selectedUnit.unitName}");
        Unit ally = battle.selectedUnit;

        ally.currentHP += (int)(ally.maxHP * 0.3);
        if (ally.currentHP > ally.maxHP)
            ally.currentHP = ally.maxHP;

        battle.selectedUnit.Deselect();
        battle.selectedUnit = null;
        Debug.Log("Action complete! Ending Charlie's turn...");

        self.A2Charge += Mathf.Clamp(0.2f, 0, 1);
        self.cooldown = 2;
        battle.NextInOrder();
    }


    public void SpecialAtk2(Unit self, Unit[] allies, Unit[] enemies)
    {
        Debug.Log("Charlie uses special attack 2!");

        foreach (Unit ally in allies)
        {
            if (ally == null) continue;
            Debug.Log("enemy currentHP is " + ally.currentHP);
            ally.currentHP += (int)(ally.currentHP * (0.25f / (1f / self.A2Charge)));
            if (ally.currentHP > ally.maxHP) 
                ally.currentHP = ally.maxHP;
            Debug.Log("raised HP to " + ally.currentHP);
        }
        Debug.Log("Action complete! Ending Charlie's turn...");
        self.order = 0;
        battle.NextInOrder();
    }




}
