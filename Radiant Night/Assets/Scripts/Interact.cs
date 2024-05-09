using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Interact : MonoBehaviour
{
    public TextMeshProUGUI text;
    bool canInteract = false;


    private void Start ()
    {
        text.enabled = false;
    }

    private void Update()
    {
        //if (canInteract)
            //HandleInteraction();
    }



    void OnTriggerEnter2D (Collider2D hit)
    {
        if (hit.gameObject.CompareTag("NPC"))
        {
            text.enabled = true;
            canInteract = true;
        }
    }
    void OnTriggerExit2D(Collider2D hit)
    {
        if (hit.gameObject.CompareTag("NPC"))
        {
            text.enabled = false;
            canInteract = false;
        }
    }

    //void HandleInteraction()
    

}
