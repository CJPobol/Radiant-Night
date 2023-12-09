using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Interact : MonoBehaviour
{
    public TextMeshProUGUI text;

    void Start ()
    {
        text.enabled = false;
    }


    void OnCollisionEnter2D (Collision2D hit)
    {
        if (hit.gameObject.CompareTag("NPC"))
        {
            text.enabled = true;
        }
    }
    void OnCollisionExit2D(Collision2D hit)
    {
        if (hit.gameObject.CompareTag("NPC"))
        {
            text.enabled = false;
        }
    }
}
