using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charlie : MonoBehaviour, IAttackable
{
    public void BasicAtk(Unit self, Unit[] allies, Unit[] enemies)
    {
        Debug.Log("Charlie uses basic attack!");

    }
    public void SpecialAtk1(Unit self, Unit[] allies, Unit[] enemies)
    {
        Debug.Log("Charlie uses special attack 1!");
    }
    public void SpecialAtk2(Unit self, Unit[] allies, Unit[] enemies)
    {
        Debug.Log("Charlie uses special attack 2!");
    }

    


}
