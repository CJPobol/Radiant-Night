using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Category { Story, Character, World, Tutorial }


[System.Serializable]
public class Quest
{
    public string questName;
    public string questDescription;
    public string questReward; //TODO: this should be something better than a string at some point
    public Category questCategory;
}
