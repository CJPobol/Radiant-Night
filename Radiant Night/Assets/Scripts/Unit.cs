using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    public string unitName;
    public int unitLevel;

    public int maxHP;
    public int currentHP;
    public Slider healthbar;

    public int atk;
    public int def;
    public float speed;
    public float order;

    public float critChance;
    public float critDmg;
}
