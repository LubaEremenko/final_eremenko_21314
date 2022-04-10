using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    public static Puzzle instance;

    List<Tile> tileList = new List<Tile>();
    public List<Vector3> solvedList = new List<Vector3>();


    public int shuffleAmount = 5;
    int[] directions = new int[] { 1, -1 };


    void Awadke()
    {
        instance = this;
    }
   
    
    
    // Start is called before the first frame update
    void Start()
    {

        tileList.AddRange(GetComponentsInChildren<Tile>());
        ShufflePuzzle();
    }

    void ShufflePuzzle()
    {   //copy current state
        foreach(Tile tile in tileList)
        {
            solvedList.Add(tile.transform.localEulerAngles);

        }
        //shuffle
        for(int i = 0; i < shuffleAmount; i++)
        {
            for (int j = 0; j < tileList.Count; j++)
            {
                int direction = directions[Random.Range(0, directions.Length)];
                tileList[j].transform.rotation *= Quaternion.Euler(0, 0, tileList[j].rotationAngle * direction);

                //round the rotation
                tileList[j].transform.localEulerAngles = Helper.RoundRotation(tileList[j].transform.localEulerAngles);


            }


        }

    }



    public bool CheckIfSolved()
    {
        for(int i = 0; i <solvedList.Count; i++)
        {
            if(tileList[i].isDistractionTile)
            {
                continue; // check if tile is a distraction tile
            }



            if(tileList[i].angle == Tile.Angles.SQUARE)
            {       
                //cross check
                if(tileList[i].IsCross())
                {
                    continue;  //hop over this tile iteration
                }

                //straight check
                if (tileList[i].IsStraight())
                {
                    if (tileList[i].transform.localEulerAngles == solvedList[i] + new Vector3(0, 0, 180))
                    {
                        continue;
                    }

                    if (tileList[i].transform.localEulerAngles == solvedList[i] + new Vector3(0, 0, -180))
                    {
                        continue;
                    }



                    if (tileList[i].transform.localEulerAngles != solvedList[i])
                    {
                        Debug.Log("not solved yet");
                        return false;
                    }

                }


            }

            if(tileList[i].transform.localEulerAngles != solvedList[i])
            {
                Debug.Log("not solved yet");
                return false;
            }
        }


        //tiles are not rotatable anymore if time over
        DeactivateAllTiles();

        //report to the game manager
        GameManager.instance.HasWon();

        Debug.Log("solved");
        return true;
    }

    public void DeactivateAllTiles()
    {
        //tiles are not rotatable anymore if time over
        foreach (Tile tile in tileList)
        {
            tile.CanNotRotate();
        }
    }

}
