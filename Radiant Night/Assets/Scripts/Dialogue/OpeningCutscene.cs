using Ink.Parsed;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningCutscene : MonoBehaviour
{
    [SerializeField] private TextAsset openingCutscene;
    public bool skip_cutscene;
    static OpeningCutscene instance;

    private void Awake()
    {
        instance = this;
    }

    public void StartCutscene()
    {
        FindObjectOfType<DialogueManager>().EnterDialogueMode(openingCutscene);
    }

    public static OpeningCutscene GetInstance()
    {
        return instance;
    }

    public void SkipCutscene()
    {
        FindObjectOfType<DialogueManager>().ExitDialogueMode();
    }
}
