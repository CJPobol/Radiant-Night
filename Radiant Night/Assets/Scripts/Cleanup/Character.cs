using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("======GENERAL=======")]
    [SerializeField] public string NPCName;


    [Header("======MOVEMENT=======")]
    public GameObject[] waypoints;  // Array of waypoints for the NPC to follow
    private int currentWaypointIndex = 0;  // Keeps track of the current waypoint
    public float speed = 2f;  // Movement speed of the NPC
    public bool isWaiting;

    public bool stepBased; //allows for moving here, something happens, then moving there.
    public bool looping; //allows for repeating movement patterns.
    public bool following; //allows for NPCs to follow the player's movement.


    [Header("======COMBAT=======")]
    public GameObject combatUnit; //the prefab used in combat mode for this NPC

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
