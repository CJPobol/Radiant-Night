using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTrigger : MonoBehaviour
{
    public bool forceTrigger;

    public GameObject player;
    public GameObject visualCue;

    [Header("------LOCATION TRIGGER------")]
    public bool locationTrigger;
    public GameObject location;
    public string locationName;

    [Header("------SCENE TRIGGER------")]
    public bool sceneTrigger;
    public string sceneName;

    
    
    private bool playerInRange;
    private bool locked;

    private void Start()
    {
        playerInRange = false;

        if (this.GetComponent<LockedArea>() == null)
        {
            locked = false;
        }
        else
            locked = true;
    }

    private void Update()
    {
        if (Input.GetButtonDown("interact") && playerInRange)
        {
            //if the area is not restricted OR it is restricted but has been unlocked.
            if (locked == false || (locked && this.GetComponent<LockedArea>().isUnlocked))
            {
                MoveCharacter();
                forceTrigger = false;
            }
            else
            {
                Debug.Log("This area is locked.");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerInRange = true;
            visualCue.SetActive(true);
            visualCue.GetComponent<TextMeshProUGUI>().text = "E - " + locationName;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            visualCue.SetActive(false);
            playerInRange = false;
        }
    }

    void MoveCharacter()
    {
        if (locationTrigger)
        {
            player.transform.position = location.transform.position;
        }
        else if (sceneTrigger)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
    
}
