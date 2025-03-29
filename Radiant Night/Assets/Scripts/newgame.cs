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
    [SerializeField] Sprite ashley, ashton, ashley_walk;

    Cutscene cutscene;
    

    private void Start()
    {
        Debug.Log(DialogueManager.GetInstance());
        cutscene = Cutscene.GetInstance();
        cutscene.skip_cutscene = false;

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
        Player.SetGender(fem, ashley, ashley_walk);
        StartCoroutine(HandleStartGame());
    }

    public IEnumerator HandleStartGame()
    {
        SceneManager.LoadScene("002_Tutorial", LoadSceneMode.Additive);
        yield return new WaitUntil(() => SceneManager.loadedSceneCount == 2);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("002_Tutorial"));
        SceneManager.UnloadSceneAsync("001_MainMenu");
        Cutscene.GetInstance().StartCutscene();
    }
}
