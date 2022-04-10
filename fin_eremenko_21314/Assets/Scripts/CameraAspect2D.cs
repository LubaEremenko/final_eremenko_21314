using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAspect2D : MonoBehaviour
{

    public SpriteRenderer placeHolder;
    // Start is called before the first frame update
    void Start()
    {
        AspectFix2D();
    }

    void AspectFix2D()
    {
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float targetRatio = placeHolder.bounds.size.x / placeHolder.bounds.size.y;

        if(screenRatio >= targetRatio)
        {
            Camera.main.orthographicSize = placeHolder.bounds.size.y / 2;

        } 
        else
        {
            float difference = targetRatio / screenRatio;
            Camera.main.orthographicSize = placeHolder.bounds.size.y / 2 * difference;
        }
    }
    
}
