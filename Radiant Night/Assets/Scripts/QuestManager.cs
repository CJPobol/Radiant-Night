using Ink.Parsed;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    public TextMeshProUGUI descriptionText, rewardText;
    public Transform questContainer;
    public GameObject questItemPrefab;


    private List<Quest> quests = new List<Quest>();

    private void Start()
    {
        quests.Add(new Quest
        {
            questName = "Meeting the Brothers",
            questDescription = "Test Description",
            questReward = "Test Reward List",
            questCategory = Category.Tutorial
        });
        PopulateQuestList();
    }

    public void PopulateQuestList()
    {
        foreach (Quest quest in quests)
        {
            GameObject questItem = Instantiate(questItemPrefab, questContainer);
            questItem.GetComponentInChildren<TextMeshProUGUI>().text = quest.questName;
            questItem.GetComponent<Button>().onClick.AddListener(() => ShowQuestDetails(quest));
        }
    }

    public void AddQuest(Quest quest)
    {
        quests.Add(quest);
        PopulateQuestList();
    }

    public void ShowQuestDetails(Quest quest)
    {
        descriptionText.text = quest.questDescription;
        rewardText.text = quest.questReward;
    }
}

