using Ink.Parsed;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class newgame : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] Canvas mainCanvas, characterCanvas;
    [SerializeField] Sprite ashley, ashton;

    private void Start()
    {
        cam.transform.position = new Vector3(0, 0, 0);
        mainCanvas.GetComponentInChildren<Canvas>().enabled = true;
        characterCanvas.GetComponentInChildren<Canvas>().enabled = false;
    }

    public void HandleNewGame()
    {
        //cam.transform.position = new Vector3(-15, -15, 0);
        mainCanvas.GetComponentInChildren<Canvas>().enabled = false;
        characterCanvas.GetComponentInChildren<Canvas>().enabled = true;

    }

    public void SelectCharacter(bool fem)
    {
        if (fem)
            Player.SetGender(fem, ashley);
        else
            Player.SetGender(fem, ashton);

        SceneManager.LoadScene("002_Tutorial");
    }

}
