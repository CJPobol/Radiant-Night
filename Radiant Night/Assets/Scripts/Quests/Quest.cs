using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// category "ALL" is not for use in game, but only used for quest filtering in the journal.
public enum Category { ALL, Story, Character, World, Tutorial }


[System.Serializable]
public class Quest
{
    public string questName;
    public string questCode;
    public string questDescription;
    public string questGuide;
    public string questReward; //TODO: this should be something better than a string at some point
    public Category questCategory;
    public bool activeQuest;

    public string category; //string from json, will be converted to enum

    public void ParseCategory()
    {
        if (!Enum.TryParse(category, true, out questCategory)) // Case-insensitive parsing
        {
            Debug.LogWarning($"Invalid category '{category}', defaulting to Story.");
            questCategory = Category.Story;
        }
    }
}
