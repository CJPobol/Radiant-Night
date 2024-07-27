using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningCutscene : MonoBehaviour
{
    [SerializeField] private TextAsset openingCutscene;
    private void Start()
    {
        DialogueManager.GetInstance().EnterDialogueMode(openingCutscene);
    }
}
