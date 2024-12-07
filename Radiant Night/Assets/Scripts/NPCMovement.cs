using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    [SerializeField] private Sprite sprite;

    [SerializeField] private GameObject[] waypoints;
    [SerializeField] private float speed;
    public DialogueManager DialogueManager;

    public bool looping;

    private void Update()
    {
        if (!DialogueManager.dialogueIsPlaying)
        {
            int i = 0;
            this.transform.position = 
                Vector3.MoveTowards(this.transform.position, waypoints[i].transform.position, speed);
            if (this.transform.position.x > waypoints[i].transform.position.x)
                GetComponent<SpriteRenderer>().flipX = true;
            else if (this.transform.position.x < waypoints[i].transform.position.x)
                GetComponent<SpriteRenderer>().flipX = false;
            else if (this.transform.position == waypoints[i].transform.position)
                i++;
            if (i == waypoints.Length && looping)
            {
                i = 0;
            }
        }
    }
}
