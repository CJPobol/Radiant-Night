using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class Player : MonoBehaviour
{
    public static Sprite default_model;
    public static Sprite model;
    public static Sprite walking_model;
    public static bool gender; //0 for male, 1 for female

    public static void SetGender(bool fem, Sprite genderedModel)
    {
        if (!genderedModel)
        {
            genderedModel = default_model;
        }

        model = genderedModel;
        gender = fem;
    }
}
