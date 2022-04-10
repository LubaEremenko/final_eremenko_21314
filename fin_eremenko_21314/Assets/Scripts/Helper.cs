using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Helper : MonoBehaviour
{
   public static Vector3 RoundRotation(Vector3 vectorToRound)
    {
        return new Vector3(Mathf.RoundToInt(vectorToRound.x),
                            Mathf.RoundToInt(vectorToRound.y),
                            Mathf.RoundToInt(vectorToRound.z));
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("puzzle_levelSelect");
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
