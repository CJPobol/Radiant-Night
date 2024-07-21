using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    private bool playerInRange;

    private void Awake()
    {
        visualCue.SetActive(false);
        playerInRange = false;
    }

    private void Update()
    {
        visualCue.SetActive(playerInRange);
        if (playerInRange && Input.GetButtonDown("interact"))
        {
            DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            playerInRange = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }
}
