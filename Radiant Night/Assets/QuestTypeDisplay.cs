using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestTypeDisplay : MonoBehaviour
{
    public GameObject panel;
    public Category category;


    private void Start()
    {
        Debug.Log(category.ToString());
        switch (category) {
            case Category.Story:
                panel.GetComponent<Image>().color = Color.green;
                break;
            case Category.Character:
                panel.GetComponent<Image>().color = Color.magenta;
                break;
            case Category.World:
                panel.GetComponent<Image>().color = Color.blue;
                break;
            case Category.Tutorial:
                panel.GetComponent<Image>().color = Color.red;
                break;
            default:
                Debug.LogError("Quest Item does not have a valid category: " + category);
                break; 
        }


        
    }

}
