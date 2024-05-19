using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI textElement;
    Dialogue dialogue;
    public float textSpeed;
    private int index;

    // Start is called before the first frame update
    private void Start()
    {
        textElement.text = string.Empty;
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textElement.text == dialogue.lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textElement.text = dialogue.lines[index];
            }
        }
    }

    public void StartDialogue(Dialogue text)
    {
        dialogue = text;
        textElement.text = string.Empty;
        gameObject.SetActive(true);
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in dialogue.lines[index].ToCharArray()) 
        {
            textElement.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < dialogue.lines.Length - 1)
        {
            index++;
            textElement.text = string.Empty;
            StartCoroutine (TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
            FindObjectOfType<Interact>().interacting = false;
        }
    }
}
