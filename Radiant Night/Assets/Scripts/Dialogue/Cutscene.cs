using Ink.Parsed;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene : MonoBehaviour
{
    [SerializeField] private TextAsset inkfile;
    public bool skip_cutscene;
    static Cutscene instance;

    private void Awake()
    {
        instance = this;
    }

    public void StartCutscene()
    {
        //THIS IS HARD CODED AS A QUEST STARTER AT THE MOMENT
        FindObjectOfType<DialogueManager>().EnterDialogueMode(inkfile, true);
    }

    public static Cutscene GetInstance()
    {
        return instance;
    }

    public void SkipCutscene()
    {
        FindObjectOfType<DialogueManager>().ExitDialogueMode();
    }
}
