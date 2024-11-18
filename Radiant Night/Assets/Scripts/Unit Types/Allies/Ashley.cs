using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ashley : MonoBehaviour, IAttackable
{
    public void BasicAtk()
    {
        Debug.Log("Ashley uses basic attack!");
        /*int rawDamage = (int)System.Math.Round(this.atk * 0.30);
        //TODO: determine critical hits based on random chance
        int defendedDamage = enemy.def / 10;
        enemy.currentHP -= rawDamage - defendedDamage;*/
    }

    public void SpecialAtk1()
    {
        Debug.Log("Ashley uses special attack 1!");
    }

    public void SpecialAtk2()
    {
        Debug.Log("Ashley uses special attack 2!");
    }

}
