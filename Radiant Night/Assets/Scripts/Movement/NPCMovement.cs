using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    [SerializeField] public string NPCName;
    [SerializeField] private Sprite idle_sprite, walking_sprite;
    [SerializeField] private Transform startingPosition;

    public GameObject[] waypoints;  // Array of waypoints for the NPC to follow
    private int currentWaypointIndex = 0;  // Keeps track of the current waypoint
    public float speed = 2f;  // Movement speed of the NPC
    public bool isWaiting;

    public bool stepBased; //allows for moving here, something happens, then moving there.
    public bool looping; //allows for repeating movement patterns.
    public bool following; //allows for NPCs to follow the player's movement.

    void Start()
    {
        if (startingPosition)
        {
            transform.position = startingPosition.position;
        }
        // Fallback if no starting position: Ensure the NPC is at the first waypoint at the start
        else if (waypoints.Length > 0)
        {
            transform.position = waypoints[0].transform.position;
        }
        isWaiting = stepBased;  // Start waiting if step-based is enabled

        if (!stepBased)
        {
            StartMoving();  // Start movement immediately if not step-based
        }
    }

    public void StartMoving()
    {
        if (following)
        {
            StartCoroutine(FollowPlayer());
        }
        else
        {
            StartCoroutine(MoveAlongWaypoints());
        }
        
    }

    private IEnumerator FollowPlayer()
    {
        Player player = FindObjectOfType<Player>(); // Cache reference to player
        if (player == null) yield break; // Safety check

        while (true) // Keep following the player
        {
            Vector3 targetPosition = player.transform.position - new Vector3(2, 0, 0);
            Vector3 startPosition = transform.position;
            float journeyLength = Vector3.Distance(startPosition, targetPosition);
            float journeyTime = journeyLength / speed;
            float elapsedTime = 0f;            

            while (elapsedTime < journeyTime)
            {
                targetPosition = player.transform.position - new Vector3(2, 0, 0); // Continuously update target position
                transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / journeyTime);
                elapsedTime += Time.deltaTime;
                yield return null;
            }


            //transform.position = player.transform.position - new Vector3(2, 0, 0); // Snap to exact position

            yield return null; // Prevents an infinite loop crash
        }
    }

    private IEnumerator MoveAlongWaypoints()
    {
        // Loop through each waypoint
        while (currentWaypointIndex < waypoints.Length)
        {
            if (isWaiting) yield break;
            else
            {
                Transform targetWaypoint = waypoints[currentWaypointIndex].transform;
                Vector3 startPosition = transform.position;
                float journeyLength = Vector3.Distance(startPosition, targetWaypoint.position);
                float journeyTime = journeyLength / speed; // Ensures constant speed
                float elapsedTime = 0f;

                Debug.Log("Moving to waypoint: " + currentWaypointIndex + " | Distance: " + journeyLength);

                while (elapsedTime < journeyTime)
                {
                    transform.position = Vector3.Lerp(startPosition, targetWaypoint.position, elapsedTime / journeyTime);
                    elapsedTime += Time.deltaTime;
                    if (targetWaypoint.transform.position.x > transform.position.x)
                    {
                        GetComponent<SpriteRenderer>().flipX = false;
                    }
                    else if (targetWaypoint.transform.position.x < transform.position.x)
                    {
                        GetComponent<SpriteRenderer>().flipX = true;
                    }
                    yield return null;
                }

                

                transform.position = targetWaypoint.position; // Snap to exact position
                currentWaypointIndex++;
                if (stepBased)
                {
                    WaitAtWaypoint(); // stop and wait for a next waypoint tag in dialogue
                    yield break;
                }
            }

        }
        
    }

    // Set the NPC to stop and wait for the player (when dialogue starts)
    public void WaitAtWaypoint()
    {
        this.GetComponent<SpriteRenderer>().sprite = idle_sprite;
        isWaiting = true;
    }

    // Set the NPC to stop waiting and resume movement
    public void StopWaiting()
    {
        this.GetComponent<SpriteRenderer>().sprite = walking_sprite;
        isWaiting = false;
        //StopCoroutine(MoveAlongWaypoints());
        StartMoving();
    }

}
