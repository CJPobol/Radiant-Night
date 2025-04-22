using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class Player : MonoBehaviour
{
    Vector2 position;

    public Unit[] ownedChars;

    public QuestDatabase QuestDB;

    private void Update()
    {
        position = this.GetComponent<Movement>().player.transform.position;
    }


    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }
    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        position.x = data.position[0];
        position.y = data.position[1];

        this.GetComponent<Movement>().UpdatePosition(position);

        for (int i = 0; i < data.unitName.Length; i++)
        {
            ownedChars[i].unitName = data.unitName[i];
            ownedChars[i].unitLevel = data.unitLevel[i];
            ownedChars[i].atk = data.atk[i];
            ownedChars[i].def = data.def[i];
            ownedChars[i].speed = data.speed[i];
            ownedChars[i].critChance = data.critChance[i];
            ownedChars[i].critDmg = data.critDmg[i];
        }

        for (int i = 0; i < data.questCode.Length; i++)
        {
            Quest newQuest = new Quest();
            newQuest.questCode = data.questCode[i];
            newQuest.questName = data.questName[i];
            newQuest.questDescription = data.questDescription[i];
            newQuest.questGuide = data.questGuide[i];
            newQuest.questReward = data.questReward[i];
            newQuest.category = data.questCategory[i];
            QuestDB.quests.Add(newQuest);
        }
    }

}
