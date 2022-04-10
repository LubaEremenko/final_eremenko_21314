using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{

    Puzzle puzzle;
    float rotationSpeed = 300;
    bool isRotating;
    bool canRotate = true;

    public bool isCross;
    public bool isStraight;
    public bool isDistractionTile;
        
    [HideInInspector] public int rotationAngle;
    
    public enum Angles
    {
        SQUARE,
        TRIANGLE,
        HEXAGON
    }
    public Angles angle;


    // Start is called before the first frame update
    void Awake()
    {
        //rotation round
        transform.localEulerAngles = Helper.RoundRotation(transform.localEulerAngles);

        switch (angle)
        {

            case Angles.HEXAGON:
            {
            rotationAngle = 60;
            }
                 break;

            case Angles.SQUARE:
            {
            rotationAngle = 90;
            }
                break;

            case Angles.TRIANGLE:
            {
            rotationAngle = 120;
            }
                break;
        }
    }
         
    void Start ()
    {
        puzzle = GetComponentInParent<Puzzle>();
    }

    
      
    

    // read input, mouse action
    void OnMouseOver()
    {
        if(canRotate)
        {


            if (Input.GetMouseButtonDown(0)) //left mouse button
            {
                StartCoroutine(Rotate(-1));
                Debug.Log("Left Clicked");
            }
            else if (Input.GetMouseButtonDown(1)) //right mouse button
            {
                StartCoroutine(Rotate(1));
                Debug.Log("right Clicked ");
            }


        }

       
    }

    IEnumerator Rotate(int direction)
    {
        if(isRotating)
        {
            yield break;
            
        }
        isRotating = true;

        Quaternion rotation = transform.rotation * Quaternion.Euler(0, 0, rotationAngle * direction); // because rotation z 

        while(RotateTowards(rotation))
        {
            yield return null;
                 
        }

        //rotation round
        transform.localEulerAngles = Helper.RoundRotation(transform.localEulerAngles);


        if(!isDistractionTile) // except distraction tiles
         {
            // check if puzzle solved
            puzzle.CheckIfSolved();
          
        }

        isRotating = false;


    }

    bool RotateTowards(Quaternion toward)
    {
        return toward != (transform.rotation = Quaternion.RotateTowards(transform.rotation, toward, rotationSpeed * Time.deltaTime));
        
    }

    public bool IsCross()
    {
        return isCross;
    }

    public bool IsStraight()
    {
        return isStraight;
    }

    public void CanNotRotate()
    {
        canRotate = false;
    }


}
