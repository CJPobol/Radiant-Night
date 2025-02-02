using Ink.Parsed;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    public TextMeshProUGUI descriptionText, rewardText;
    public Transform questContainer;
    public GameObject questItemPrefab;

    public GameObject questSystem;

    private List<Quest> quests = new List<Quest>();


    private static QuestManager instance;
    private void Start()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one Quest Manager.");
        }
        instance = this;

        quests.Add(new Quest
        {
            questName = "Meeting the Brothers",
            questDescription = "A stranger calling himself “Charlie” has offered to bring you back to his house. You’ve always been told to be wary of people you’ve never met, but where else could you even go?",
            questReward = "Test Reward List 1",
            questCategory = Category.Tutorial
        });
        quests.Add(new Quest
        {
            questName = "Search the Forest",
            questDescription = "With odd machine-like creatures running around on Earth, you feel as though it is your duty to investigate and protect the Earthlings. To do so, you’ll need to find more of them in the forest you landed in.",
            questReward = "Test Reward List 2",
            questCategory = Category.Story
        });
        quests.Add(new Quest
        {
            questName = "College Day",
            questDescription = "Jacke has offered to take you along with them to college for a day. A bit of socialization might do you some good, maybe you should take them up on it! ",
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) 
            ToggleQuestMenu();
    }

    public static QuestManager GetInstance()
    {
        return instance;
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
        //TODO: pop up telling the player a new quest has been added to their journal
        quests.Add(quest);
        PopulateQuestList();
    }

    public void ShowQuestDetails(Quest quest)
    {
        descriptionText.text = quest.questDescription;
        rewardText.text = quest.questReward;
    }

    private Category selectedCategory;

    public void FilterQuests()
    {
        foreach (Transform child in questContainer)
        {
            Quest quest = quests.Find(q => q.questName == child.GetComponentInChildren<TextMeshProUGUI>().text);
            if (selectedCategory == Category.ALL)
                child.gameObject.SetActive(true);
            else
                child.gameObject.SetActive(quest.questCategory == selectedCategory || selectedCategory == 0);
        }
    }

    public void AllSelect()
    {
        selectedCategory = Category.ALL;
        FilterQuests();
    }

    public void StorySelect()
    {
        selectedCategory = Category.Story;
        FilterQuests();
    }

    public void CharacterSelect()
    {
        selectedCategory = Category.Character;
        FilterQuests();
    }

    public void WorldSelect()
    {
        selectedCategory = Category.World;
        FilterQuests();
    }

    public void ToggleQuestMenu()
    {
        if (questSystem.gameObject.activeSelf)
        {
            questSystem.gameObject.SetActive(false);
        }
        else
            questSystem.gameObject.SetActive(true);
    }
}

