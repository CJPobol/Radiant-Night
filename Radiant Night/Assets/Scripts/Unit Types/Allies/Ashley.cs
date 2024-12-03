using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ashley : MonoBehaviour, IAttackable
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
        Debug.Log("Ashley uses basic attack!");
        int rawDamage = (int)System.Math.Round(self.atk * 0.30);
        
        for (int i = 0; i < enemies.Length; i++)
        {
            int defendedDamage = enemies[i].def / 10;
            enemies[i].currentHP -= rawDamage - defendedDamage;
        }
        battle.turnActive = false;
        self.order = 0;
        battle.NextInOrder();
    }

    public void SpecialAtk1(Unit self, Unit[] allies, Unit[] enemies)
    {
        Debug.Log("Ashley uses special attack 1!");
        for (int i = 0; i < battle.enemySelectors.Length; i++)
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

        Debug.Log($"Selected Enemy {battle.selectedUnit.unitName}");
        Unit ally = battle.selectedUnit;

        ally.order += 100;

        battle.selectedUnit.Deselect();
        battle.selectedUnit = null;
        Debug.Log("Action complete! Ending Ashley's turn...");

        
        self.cooldown = 2;
        battle.NextInOrder();
    }

    public void SpecialAtk2(Unit self, Unit[] allies, Unit[] enemies)
    {
        Debug.Log("Ashley uses special attack 2!");
        self.order = 0;
        battle.NextInOrder();
    }

}
