using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jacke : MonoBehaviour, IAttackable
{
    GameObject combatManager;
    BattleSystem battle;

    private void Start()
    {
        combatManager = FindObjectOfType<BattleSystem>()?.gameObject;
        battle = combatManager.GetComponent<BattleSystem>();
    }

    public void BasicAtk(Unit self, Unit[] allies, Unit[] enemies)
    {
        Debug.Log("Jacke uses basic attack!");

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
        yield return new WaitUntil(() => battle.selectedEnemy != null);
        Debug.Log($"Selected Enemy {battle.selectedEnemy.unitName}");
        Unit enemy = battle.selectedEnemy;

        enemy.currentHP -= self.atk;
        battle.isSelectingEnemyUnit = false;
        battle.selectedEnemy.Deselect();
        battle.selectedEnemy = null;
        Debug.Log("Action complete! Ending Jacke's turn...");
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
        Debug.Log("Jacke uses special attack 1!");
        self.order = 0;
        battle.NextInOrder();

    }
    public void SpecialAtk2(Unit self, Unit[] allies, Unit[] enemies)
    {
        Debug.Log("Jacke uses special attack 2!");
        self.order = 0;
        battle.NextInOrder();
    }




}

