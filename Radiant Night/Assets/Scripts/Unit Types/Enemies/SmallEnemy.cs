using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallEnemy : MonoBehaviour, IAttackable
{
    public void BasicAtk()
    {
        Debug.Log("Enemy uses basic attack!");
    }
    public void SpecialAtk1()
    {
        Debug.Log("Enemy uses special attack 1!");
    }
    public void SpecialAtk2()
    {
        Debug.Log("Enemy uses special attack 2!");
    }
}
