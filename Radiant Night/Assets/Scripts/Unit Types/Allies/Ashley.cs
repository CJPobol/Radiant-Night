using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ashley : Unit
{
    public void BasicAttack(Unit enemy)
    {
        int rawDamage = (int)System.Math.Round(this.atk * 0.30);
        //TODO: determine critical hits based on random chance
        int defendedDamage = enemy.def / 10;
        enemy.currentHP -= rawDamage - defendedDamage;
    }

    public void SpecialAttack1()
    {

    }

    public void SpecialAttack2()
    {

    }

}
