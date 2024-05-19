using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject dialogueManager;

    public void TriggerDialogue()
    {
        dialogueManager.GetComponent<DialogueManager>().StartDialogue(dialogue);
    }
}
