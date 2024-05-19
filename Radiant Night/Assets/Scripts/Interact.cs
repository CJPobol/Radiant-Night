using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using JetBrains.Annotations;

public class Interact : MonoBehaviour
{
    public TextMeshProUGUI tooltip;
    bool canInteract = false;
    GameObject interactable;

    private void Start ()
    {
        tooltip.enabled = false;
    }

    private void Update()
    {
        if (Input.GetButtonDown("interact") && canInteract) 
        {
            Debug.Log("interact button pressed");
            interactable.GetComponent<DialogueTrigger>().TriggerDialogue();
            canInteract = false;
            tooltip.enabled = false;
        }
    }



    void OnTriggerEnter2D (Collider2D hit)
    {
        if (hit.gameObject.CompareTag("NPC"))
        {
            tooltip.enabled = true;
            tooltip.text = "E - Talk";
            canInteract = true;
            interactable = hit.gameObject;
        }
    }
    void OnTriggerExit2D(Collider2D hit)
    {
        if (hit.gameObject.CompareTag("NPC"))
        {
            tooltip.enabled = false;
            canInteract = false;
            interactable = null;
        }
    }

    
}
