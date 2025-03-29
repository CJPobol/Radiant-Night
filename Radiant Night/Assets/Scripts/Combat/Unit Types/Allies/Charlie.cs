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
        self.order = 0;
        battle.NextInOrder();
        
    }
    public void SpecialAtk2(Unit self, Unit[] allies, Unit[] enemies)
    {
        Debug.Log("Charlie uses special attack 2!");
        self.order = 0;
        battle.NextInOrder();
    }

    


}
