using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLoader : MonoBehaviour
{
    public List<string> levelList = new List<string>();
    public GameObject buttonPrefab;


    // Start is called before the first frame update
    void Start()
    {
        CreateButton();
    }

    void CreateButton()
    {

        for (int i = 0; i < levelList.Count; i++)
        {
            GameObject newButton = Instantiate(buttonPrefab, this.transform);
            newButton.GetComponent<LevelButton>().levelToLoad = levelList[i];

            newButton.GetComponentInChildren<Text>().text = (i + 1).ToString();
        }
    }
        
    
}
