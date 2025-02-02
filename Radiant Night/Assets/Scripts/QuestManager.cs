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
            questDescription = "Test Description 1",
            questReward = "Test Reward List 1",
            questCategory = Category.Tutorial
        });
        quests.Add(new Quest
        {
            questName = "Search the Forest",
            questDescription = "Test Description 2",
            questReward = "Test Reward List 2",
            questCategory = Category.Story
        });
        quests.Add(new Quest
        {
            questName = "College Day",
            questDescription = "Test Description 3",
            questReward = "Test Reward List 3",
            questCategory = Category.Character
        });
        quests.Add(new Quest
        {
            questName = "Robot Extermination",
            questDescription = "Test Description 4",
            questReward = "Test Reward List 4",
            questCategory = Category.World
        });
        PopulateQuestList();
    }

    public void PopulateQuestList()
    {
        foreach (Quest quest in quests)
        {
            GameObject questItem = Instantiate(questItemPrefab, questContainer);
            questItem.GetComponentInChildren<TextMeshProUGUI>().text = quest.questName;
            questItem.GetComponent<QuestTypeDisplay>().category = quest.questCategory;
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

