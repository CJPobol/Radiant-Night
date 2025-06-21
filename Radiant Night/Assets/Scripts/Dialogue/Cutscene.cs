using Ink.Parsed;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cutscene : MonoBehaviour
{
    [SerializeField] private TextAsset inkfile;
    private string knot;
    public Toggle skip_cutscene;
    static Cutscene instance;

    private void Awake()
    {
        instance = this;
    }

    public void StartCutscene()
    {
        bool value = skip_cutscene.isOn;
        if (value)
            knot = "CharlieIntroBrief";
        else
            knot = "START";

        Debug.Log(knot);
        //THIS IS HARD CODED AS A QUEST STARTER AT THE MOMENT
        FindObjectOfType<DialogueManager>().EnterDialogueMode(inkfile, true, knot);
    }

    public static Cutscene GetInstance()
    {
        return instance;
    }

}
