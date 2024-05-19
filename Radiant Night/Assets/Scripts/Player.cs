using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class Player : MonoBehaviour
{
    public static Sprite model;
    public static bool gender; //0 for male, 1 for female

    public static void SetGender(bool fem, Sprite genderedModel)
    {
        model = genderedModel;
        gender = fem;
    }
}
