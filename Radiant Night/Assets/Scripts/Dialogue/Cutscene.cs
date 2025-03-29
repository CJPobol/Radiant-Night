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
        FindObjectOfType<DialogueManager>().EnterDialogueMode(inkfile);
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
