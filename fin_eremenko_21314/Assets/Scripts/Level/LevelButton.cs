using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    public string levelToLoad;

    public List<GameObject> spacerList = new List<GameObject>();
    public int spacerId;

    public void ButtonClick()
    {
        if(levelToLoad != "")
        {
            SceneManager.LoadScene(levelToLoad);
        }
    }

    public void TypeButtonClick()
    {
        foreach (var item in spacerList)
        {
            item.SetActive(false);
        }

        spacerList[spacerId].SetActive(true);
    }

}
