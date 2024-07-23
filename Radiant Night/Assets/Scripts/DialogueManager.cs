using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using Unity.PlasticSCM.Editor.WebApi;
using System;
using Unity.VisualScripting;
using UnityEngine.SearchService;

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

    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choiceText;
    
    private Story currentStory;

    private const string SPEAKER_TAG = "speaker";
    private const string PORTRAIT_TAG = "portrait";

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
    }

    private void Start()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);

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

        if (Input.GetMouseButtonDown(0))
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

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);

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
                    Debug.Log("Speaker =" +  tag);
                    dialogueNameDisplay.text = tagValue;
                    break;
                case PORTRAIT_TAG:
                    Debug.Log("Portrait =" + tag);
                    portraitAnimator.Play(tagValue);
                    break;
                default:
                    Debug.LogError("Tag is not currently being handled: " + tag);
                    break;
            }
        }
    }

    private IEnumerator DisplayLine(string line)
    {
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

    private void ExitDialogueMode()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
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
