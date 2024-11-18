using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charlie : MonoBehaviour, IAttackable
{
    public void BasicAtk()
    {
        Debug.Log("Charlie uses basic attack!");
    }
    public void SpecialAtk1()
    {
        Debug.Log("Charlie uses special attack 1!");
    }
    public void SpecialAtk2()
    {
        Debug.Log("Charlie uses special attack 2!");
    }
}
