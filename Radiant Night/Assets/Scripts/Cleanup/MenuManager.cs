using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject main, combat, character, quest, dialogue;
    public MenuState menuState;
    public static MenuManager instance;
    public enum MenuState 
    { 
        MAIN_MENU,
        COMBAT_INTERFACE,
        CHARACTER_MENU,
        QUEST_MENU,
        DIALOGUE_INTERFACE,
        
        NONE
    }

    private void Start()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one Menu Manager.");
        }
        instance = this;
    }


    public static MenuManager GetInstance()
    {
        return instance;
    }

    public void Update()
    {
        switch (menuState)
        {
            case MenuState.MAIN_MENU:
                main.SetActive(true);
                combat.SetActive(false);
                character.SetActive(false);
                quest.SetActive(false);
                dialogue.SetActive(false);
                
                break;
            case MenuState.COMBAT_INTERFACE:
                combat.SetActive(true);
                main.SetActive(false);
                character.SetActive(false);
                quest.SetActive(false);
                dialogue.SetActive(false);

                break;
            case MenuState.CHARACTER_MENU:
                character.SetActive(true);
                main.SetActive(false);
                combat.SetActive(false);
                quest.SetActive(false);
                dialogue.SetActive(false);

                break;
            case MenuState.QUEST_MENU:
                quest.SetActive(true);
                main.SetActive(false);
                character.SetActive(false);
                combat.SetActive(false);
                dialogue.SetActive(false);

                break;
            case MenuState.DIALOGUE_INTERFACE:
                dialogue.SetActive(true);
                main.SetActive(false);
                combat.SetActive(false);
                character.SetActive(false);
                quest.SetActive(false);

                break;
            default:
                main.SetActive(false);
                combat.SetActive(false);
                character.SetActive(false);
                quest.SetActive(false);
                dialogue.SetActive(false);

                break;
        }

    }


}
