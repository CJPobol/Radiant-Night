using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITools : MonoBehaviour
{
    public static void DisableButton(Button self)
    {
        self.interactable = false;
    }
    public static void EnableButton(Button self)
    {
        self.interactable = true;
    }
}
