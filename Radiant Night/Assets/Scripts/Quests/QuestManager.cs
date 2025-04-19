using Ink.Parsed;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class QuestManager : MonoBehaviour
{
    public TextMeshProUGUI descriptionText, rewardText;
    public Transform questContainer;
    public GameObject questItemPrefab;
    public GameObject popup;
    public TextMeshProUGUI questGuide;

    public GameObject questSystem;

    private Dictionary<string, Quest> quests = new Dictionary<string, Quest>();
    private Quest showingQuest, activeQuest;


    private static QuestManager instance;
    private void Start()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one Quest Manager.");
        }
        instance = this;
        questSystem.SetActive(false);

        /*AddQuest(new Quest
        {
            questName = "Meeting the Brothers",
            questDescription = "A stranger calling himself “Charlie” has offered to bring you back to his house. You’ve always been told to be wary of people you’ve never met, but where else could you even go?",
            questGuide = "Follow Charlie to his house.",
            questReward = "Test Reward List 1",
            questCategory = Category.Tutorial
        });
        AddQuest(new Quest
        {
            questName = "Search the Forest",
            questDescription = "With odd machine-like creatures running around on Earth, you feel as though it is your duty to investigate and protect the Earthlings. To do so, you’ll need to find more of them in the forest you landed in.",
            questReward = "Test Reward List 2",
            questCategory = Category.Story
        });
        AddQuest(new Quest
        {
            questName = "College Day",
            questDescription = "Jacke has offered to take you along with them to college for a day. A bit of socialization might do you some good, maybe you should take them up on it! ",
            questReward = "Test Reward List 3",
            questCategory = Category.Character
        });
        AddQuest(new Quest
        {
            questName = "Robot Extermination",
            questDescription = "A local shopkeeper has requested that you defend his ranch from the monsters roaming Earth. He offered a hefty reward for each time you fend off the beasts.",
            questReward = "Test Reward List 4",
            questCategory = Category.World
        });
        */
        LoadQuests();
    }

    private void LoadQuests()
    {
        // Load JSON file from Resources
        TextAsset jsonFile = Resources.Load<TextAsset>("QuestList");
        if (jsonFile == null)
        {
            Debug.LogError("Quest JSON file not found!");
            return;
        }

        // Deserialize JSON into QuestDatabase
        QuestDatabase questDatabase = JsonUtility.FromJson<QuestDatabase>(jsonFile.text);

        // Convert List to Dictionary for fast lookups
        foreach (Quest quest in questDatabase.quests)
        {
            quest.ParseCategory();
            quests[quest.questCode] = quest;
        }

        Debug.Log("Quests Loaded: " + quests.Count);
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

    public void SetActiveQuest()
    {
        if (activeQuest != null)
        {
            activeQuest.activeQuest = false;
            activeQuest = null;
        }

        if (showingQuest != null)
        {
            activeQuest = showingQuest;
            activeQuest.activeQuest = true;
        }
        questGuide.text = activeQuest.questGuide;
        Debug.Log(activeQuest.questGuide);
    }

    public void AddQuest(Quest quest)
    {
        GameObject questItem = Instantiate(questItemPrefab, questContainer);
        questItem.GetComponentInChildren<TextMeshProUGUI>().text = quest.questName;
        questItem.GetComponent<QuestTypeDisplay>().category = quest.questCategory;
        questItem.GetComponent<Button>().onClick.AddListener(() => ShowQuestDetails(quest));
        
        StartCoroutine(MakePopup());
    }

    public void AddQuest(string QuestCode)
    {
        Quest foundQuest = null;

        foreach (Quest quest in quests.Values)
        {
            if (quest.questCode == QuestCode)
            {
                foundQuest = quest;
                break;  // Stop searching after finding the first match
            }
        }

        if (foundQuest != null)
        {
            Debug.Log("Found quest: " + foundQuest.questName);
            AddQuest(foundQuest);
        }
        else
        {
            Debug.Log("Quest not found!");
        }
        
    }

    public IEnumerator MakePopup()
    {
        popup.SetActive(true);
        yield return new WaitForSeconds(3);
        for (float f = 1; f > -0.04f; f -= 0.04f)
        {
            popup.GetComponent<CanvasGroup>().alpha = f;
            yield return new WaitForSeconds(0.01f);
        }
        popup.SetActive(false);
    }

    public void ShowQuestDetails(Quest quest)
    {
        showingQuest = quest;
        descriptionText.text = quest.questDescription;
        rewardText.text = quest.questReward;
    }

    private Category selectedCategory;

    public void FilterQuests()
    {
        foreach (Transform child in questContainer)
        {
            Quest quest = quests.Values.FirstOrDefault(q => q.questName == child.GetComponentInChildren<TextMeshProUGUI>().text);
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

