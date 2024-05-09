using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Sprite model;

    public static void SetGender(bool fem, Sprite genderedModel)
    {
        model = genderedModel;
    }
}
