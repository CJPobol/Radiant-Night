using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackable
{
    void BasicAtk(Unit self, Unit[] allies, Unit[] enemies);
    void SpecialAtk1(Unit self, Unit[] allies, Unit[] enemies);
    void SpecialAtk2(Unit self, Unit[] allies, Unit[] enemies);
}
