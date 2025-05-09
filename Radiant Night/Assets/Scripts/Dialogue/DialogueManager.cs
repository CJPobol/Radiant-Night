using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using Unity.PlasticSCM.Editor.WebApi;
using System;
using Unity.VisualScripting;
using UnityEngine.SearchService;
using UnityEngine.Windows;

[System.Serializable]
public class DialogueManager : MonoBehaviour
{
    private static DialogueManager instance;

    [Header("Params")]
    [SerializeField] private float textSpeed;

    private Coroutine displayLineCoroutine;

    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueTextDisplay;
    [SerializeField] private TextMeshProUGUI dialogueNameDisplay;
    [SerializeField] private Animator portraitAnimator;
    [SerializeField] private GameObject cutscenePanel;
    [SerializeField] private GameObject player;

    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choiceText;

    //list of npcs in scene that can be referenced by tags.
    NPCMovement[] npcs;

    private Story currentStory;

    private const string SPEAKER_TAG = "speaker";
    private const string PORTRAIT_TAG = "portrait";
    private const string CUTSCENE_TAG = "cutscene";
    private const string QUEST_ADD_TAG = "quest_add";
    private const string UNLOCK_TAG = "unlock_area";
    private const string WAYPOINT_TAG = "next_waypoint";
    private const string FOLLOW_TAG = "follower";

    public bool dialogueIsPlaying { get; private set; }
    private bool canGoNextLine;
    private bool skipDialogue;
    private bool canSkip;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one Dialogue Manager.");
        }    
        
        instance = this;

        
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        cutscenePanel.SetActive(false);
        Debug.Log("Dialogue disabled on startup");
    }

    private void Start()
    {
        choiceText = new TextMeshProUGUI[choices.Length];
        int index = 0;

        foreach (GameObject choice in choices)
        {
            choiceText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }

        
    }

    private void Update()
    {
        if (!dialogueIsPlaying) return;

        if (UnityEngine.Input.GetMouseButtonDown(0))
        {
            if (canGoNextLine)
            {
                ContinueStory();
            }
            else
            {
                skipDialogue = true;
            }
        }
        
    }

    private IEnumerator CanSkip()
    {
        canSkip = false; //Making sure the variable is false.
        yield return new WaitForSeconds(0.05f);
        canSkip = true;
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }

    //changing quests, new ink file.
    public void EnterNEWStory(TextAsset inkJSON, String knot = "")
    {
        
        if (knot != "")
        {
            currentStory.ChoosePathString(knot);
        }
    }

    //new knots within the same quest you've been doing.
    public void EnterDialogueMode(TextAsset inkJSON, bool newStory, String knot = "")
    {
        //list of npcs in scene that can be referenced by tags.
        npcs = FindObjectsOfType<NPCMovement>();

        //locks idle model (still not working completely)
        player.GetComponent<Animator>().SetBool("DialogueMode", true);
        
        
        if (newStory)
        {
            currentStory = new Story(inkJSON.text);
        }
        if (knot != "")
        {
            currentStory.ChoosePathString(knot);
        }

        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);
        Debug.Log("Dialogue Panel set to active");

        ContinueStory();

        
    }

    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            if (displayLineCoroutine != null) StopCoroutine(displayLineCoroutine);
            
            //display dialogue line
            displayLineCoroutine = StartCoroutine(DisplayLine(currentStory.Continue()));
            
            HandleTags(currentStory.currentTags);
        }
        else
        {
            ExitDialogueMode();
        }
    }

    private void HandleTags(List<string> tags)
    {
        foreach (string tag in tags)
        {
            string[] splitTag = tag.Split(':');
            if (splitTag.Length != 2)
            {
                Debug.LogError("Tag could not be parsed: " + tag);
            }

            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            switch (tagKey)
            {
                case SPEAKER_TAG:
                    //Debug.Log("Speaker =" +  tagValue);
                    dialogueNameDisplay.text = tagValue;
                    break;
                case PORTRAIT_TAG:
                    //Debug.Log("Portrait =" + tagValue);
                    string name = tagValue.Split('_')[0];
                    dialogueNameDisplay.text = name[0].ToString().ToUpper() + name.Substring(1);
                    portraitAnimator.Play(tagValue);
                    break;
                case CUTSCENE_TAG:
                    //Debug.Log("Cutscene =" + tagValue);
                    switch (tagValue)
                    {
                        case "on":
                            cutscenePanel.SetActive(true);
                            break;
                        case "fade_out":
                            StartCoroutine(FadeOut(cutscenePanel.GetComponent<CanvasGroup>()));
                            break;
                        case "off":
                            cutscenePanel.SetActive(false);
                            break;
                        default:
                            Debug.LogError("Cutscene tag not recognized: " + tagValue);
                            break;
                    }
                    break;
                case QUEST_ADD_TAG:
                    QuestManager.GetInstance().AddQuest(tagValue);
                    break;
                case UNLOCK_TAG:
                    LockedArea[] areas = FindObjectsOfType<LockedArea>();
                    foreach (LockedArea area in areas)
                    { 
                        if (area.areaName == tagValue)
                        {
                            area.isUnlocked = true;
                        }
                    }
                    break;
                case WAYPOINT_TAG:
                    foreach (NPCMovement npc in npcs)
                    {
                        if (npc.NPCName == tagValue)
                        {
                            npc.StopWaiting();
                        }
                    }

                    break;
                case FOLLOW_TAG:              
                    foreach (NPCMovement npc in npcs)
                    {
                        if (npc.NPCName == tagValue)
                        {
                            npc.following = true;
                            npc.StopWaiting();
                        }
                    }
                    break;
                default:
                    Debug.LogError("Tag is not currently being handled: " + tag);
                    break;
            }
        }
    }

    public IEnumerator FadeOut(CanvasGroup rend)
    {
        for (float f = 1; f > -0.02f; f -= 0.02f)
        {
            rend.alpha = f;
            yield return new WaitForSeconds(0.05f);
        }
        cutscenePanel.SetActive(false);
    }

    private IEnumerator DisplayLine(string line)
    {
        dialoguePanel.GetComponent<AudioSource>().Play();
        //empty dialogue text
        dialogueTextDisplay.text = "";

        canGoNextLine = false;
        HideChoices();

        StartCoroutine(CanSkip());
        
        foreach(char c in line.ToCharArray())
        {
            if (skipDialogue && canSkip)
            {
                dialogueTextDisplay.text = line;
                //Debug.Log("Dialogue Skipped: " + line);
                break;
            }
            dialogueTextDisplay.text += c;
            
            yield return new WaitForSeconds(textSpeed);
        }

        dialoguePanel.GetComponent<AudioSource>().Stop();

        canGoNextLine = true;
        skipDialogue = false;
        canSkip = false;

        //display choices if applicable
        DisplayChoices();
        
    }

    private void HideChoices()
    {
        foreach (GameObject choice in choices)
        {
            choice.SetActive(false);
        }
    }

    public void ExitDialogueMode()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        cutscenePanel.SetActive(false);
        //UNLOCKS idle model
        player.GetComponent<Animator>().SetBool("DialogueMode", false);
        Debug.Log("Exiting Dialogue Mode.");
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        //if there's a choice to be made, the player can't continue until they pick something
        if (currentChoices.Count > 0)
            canGoNextLine = false;

            if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("More choices than UI can currently support. Choice count: " + currentChoices.Count);
        }

        int index = 0;

        //enable all the choices the inky file demands
        foreach (Choice choice in currentChoices)
        {
            choices[index].SetActive(true);
            choiceText[index].text = choice.text;
            index++;
        }

        //disable any extra choice elements that are not needed for this choice
        for (int i = index; i < choices.Length; i++)
        {
            choices[i].SetActive(false);
        }
    }

    public void MakeChoice(int choiceIndex)
    {
        skipDialogue = false;
        currentStory.ChooseChoiceIndex(choiceIndex);
        ContinueStory();
    }

}
