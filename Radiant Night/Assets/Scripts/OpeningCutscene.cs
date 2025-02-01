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
        skip_cutscene = false;
        instance = this;
    }

    public void StartCutscene()
    {
        Debug.Log(skip_cutscene);
        if (!skip_cutscene)
        {
            FindObjectOfType<DialogueManager>().EnterDialogueMode(openingCutscene);
        }
    }

    public static OpeningCutscene GetInstance()
    {
        return instance;
    }
}
