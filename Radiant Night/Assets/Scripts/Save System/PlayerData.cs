using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class PlayerData
{
    public float[] position;

    //Unit[] ownedChars;
    public string[] unitName;
    public int[] unitLevel;

    public int[] maxHP;
    public int[] currentHP;

    public int[] atk;
    public int[] def;
    public float[] speed;

    public float[] critChance;
    public float[] critDmg;


    //QuestDatabase qdb;
    public string[] questName;
    public string[] questCode;
    public string[] questDescription;
    public string[] questGuide;
    public string[] questReward;
    public string[] questCategory;


    public PlayerData(Player player)
    {
        position = new float[2];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;

        for (int i = 0; i < player.ownedChars.Length; i++)
        {
            unitName[i] = player.ownedChars[i].unitName;
            unitLevel[i] = player.ownedChars[i].unitLevel;

            maxHP[i] = player.ownedChars[i].maxHP;
            currentHP[i] = player.ownedChars[i].currentHP;

            atk[i] = player.ownedChars[i].atk;
            def[i] = player.ownedChars[i].def;
            speed[i] = player.ownedChars[i].speed;

            critChance[i] = player.ownedChars[i].critChance;
            critDmg[i] = player.ownedChars[i].critDmg;

        }
        
        for (int i = 0; i < player.QuestDB.quests.Count; i++)
        {
            questName[i] = player.QuestDB.quests[i].questName;
            questCode[i] = player.QuestDB.quests[i].questCode;
            questDescription[i] = player.QuestDB.quests[i].questDescription;
            questGuide[i] = player.QuestDB.quests[i].questGuide;
            questReward[i] = player.QuestDB.quests[i].questReward;
            questCategory[i] = player.QuestDB.quests[i].questCategory.ToString();
        }

    }

}
