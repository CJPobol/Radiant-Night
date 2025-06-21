using Ink.Parsed;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] Canvas mainCanvas, characterCanvas;

    private void Start()
    {
        MenuManager.GetInstance().menuState = MenuManager.MenuState.MAIN_MENU;
        cam.transform.position = new Vector3(0, 0, 0);
        mainCanvas.GetComponentInChildren<Canvas>().enabled = true;
        characterCanvas.GetComponentInChildren<Canvas>().enabled = false;
    }

    public void HandleNewGame()
    {
        //cam.transform.position = new Vector3(-15, -15, 0);
        mainCanvas.GetComponentInChildren<Canvas>().enabled = false;
        characterCanvas.GetComponentInChildren<Canvas>().enabled = true;
        
        Debug.Log(SceneManager.loadedSceneCount);
    }

    public void SelectCharacter(bool fem)
    {
        StartCoroutine(HandleStartGame());
    }

    public IEnumerator HandleStartGame()
    {
        //MenuManager.GetInstance().menuState = MenuManager.MenuState.NONE;
        yield return null;
        DialogueManager.GetInstance().GetComponent<Cutscene>().StartCutscene();
    }


}
