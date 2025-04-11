using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTrigger : MonoBehaviour
{
    public bool locationTrigger;
    public Vector2 location;
    public string locationName;

    public bool sceneTrigger;
    public string sceneName;

    public bool forceTrigger;

    public GameObject player;
    public GameObject visualCue;
    
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
            player.transform.position = location;
        }
        else if (sceneTrigger)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
    
}
