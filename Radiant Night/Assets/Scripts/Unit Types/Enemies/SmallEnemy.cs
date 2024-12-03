using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallEnemy : MonoBehaviour, IAttackable
{
    public void BasicAtk(Unit self, Unit[] allies, Unit[] enemies)
    {
        Debug.Log("Enemy uses basic attack!");
        /*int rawDamage = (int)System.Math.Round(self.atk * 0.10);

        for (int i = 0; i < allies.Length; i++)
        {
            int defendedDamage = allies[i].def / 10;
            allies[i].currentHP -= rawDamage - defendedDamage;
        }*/
        
    }
    public void SpecialAtk1(Unit self, Unit[] allies, Unit[] enemies)
    {
        Debug.Log("Enemy uses special attack 1!");
    }
    public void SpecialAtk2(Unit self, Unit[] allies, Unit[] enemies)
    {
        Debug.Log("Enemy uses special attack 2!");
    }
}
