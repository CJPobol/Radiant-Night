using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;

[System.Serializable]
public class DialogueManager : MonoBehaviour
{
    private static DialogueManager instance;

    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueTextDisplay;

    
    private Story currentStory;

    public bool dialogueIsPlaying;

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
    }

    private void Update()
    {
        if (!dialogueIsPlaying) return;

        if (Input.GetMouseButtonDown(0)) 
        {
            ContinueStory();
        }
        
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
            Debug.Log("continuing...");
            dialogueTextDisplay.text = currentStory.Continue();
        }
        else
        {
            ExitDialogueMode();
        }
    }

    private void ExitDialogueMode()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueTextDisplay.text = "";
    }

    /*public TextMeshProUGUI textElement;
    Dialogue dialogue;
    public float textSpeed;
    private int index;

    // Start is called before the first frame update
    private void Start()
    {
        textElement.text = string.Empty;
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textElement.text == dialogue.lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textElement.text = dialogue.lines[index];
            }
        }
    }

    public void StartDialogue(Dialogue text)
    {
        dialogue = text;
        textElement.text = string.Empty;
        gameObject.SetActive(true);
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in dialogue.lines[index].ToCharArray()) 
        {
            textElement.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < dialogue.lines.Length - 1)
        {
            index++;
            textElement.text = string.Empty;
            StartCoroutine (TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
            FindObjectOfType<Interact>().interacting = false;
        }
    }*/
}
