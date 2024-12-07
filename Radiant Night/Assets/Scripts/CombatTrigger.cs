using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatTrigger : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject dialogueTrigger;

    private bool playerInRange;

    private void Start()
    {
        playerInRange = false;
    }

    private void Update()
    {
        if (playerInRange)
            BeginCombat();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Trying combat");
            BeginCombat();
        }
    }

    void BeginCombat()
    {
        Debug.Log("Dialogue is done, initiating combat.");
        BattleSystem.GetInstance().combatSystem.gameObject.SetActive(true);
        BattleSystem.GetInstance().InitializeEnemies(enemies);

        this.GetComponent<Collider2D>().enabled = false;
        this.gameObject.SetActive(false);
        dialogueTrigger.SetActive(false);
    }
}
