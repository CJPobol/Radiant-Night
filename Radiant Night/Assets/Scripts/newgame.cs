using Ink.Parsed;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class newgame : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] Canvas mainCanvas, characterCanvas;
    [SerializeField] Sprite ashley, ashton;

    OpeningCutscene cutscene;
    

    private void Start()
    {
        Debug.Log(DialogueManager.GetInstance());
        cutscene = OpeningCutscene.GetInstance();

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

    public void HandleSkipCutscene()
    {
        Debug.Log(cutscene);
        cutscene.skip_cutscene = !cutscene.skip_cutscene;
    }

    public void SelectCharacter(bool fem)
    {
        StartCoroutine(HandleStartGame());
    }

    public IEnumerator HandleStartGame()
    {
        SceneManager.LoadScene("002_Tutorial", LoadSceneMode.Additive);
        yield return new WaitUntil(() => SceneManager.loadedSceneCount == 2);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("002_Tutorial"));
        SceneManager.UnloadSceneAsync("001_MainMenu");
        OpeningCutscene.GetInstance().StartCutscene();
    }
}
