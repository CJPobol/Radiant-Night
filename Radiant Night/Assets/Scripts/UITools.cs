using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITools : MonoBehaviour
{
    public void DisableButton(Button self)
    {
        self.interactable = false;
    }
}
