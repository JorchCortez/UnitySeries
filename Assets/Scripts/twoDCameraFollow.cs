using UnityEngine;
using System.Collections;


[AddComponentMenu("Delta/2D Tools/2D Camera Follow")]
public class twoDCameraFollow : MonoBehaviour {

    [Header("Target and Smooth Time")]
    /*
     * 2D Camera Follow Script
     * 
     * 
     * Enjoy the code and Good luck!!
     * 
     * Last edited by: Jorge Cortez
     * on: Thursday 1/8/2017      
     */
    [Tooltip("Place here your Player Prefab")]
    public Transform player;

    //Sets the velocity to zero
    Vector3 velocity = Vector3.zero;

    [Tooltip("Set the Smooth time of the Camera")]
    public float SmoothTime = 0.15f;

    [Header("Set Camera Limits")]

    [Tooltip("Set a Maximum Y Value to the Camera")]
    public bool SetMaxY;
    public float YMaxValue = 0;

    [Tooltip("Set a Minimum Y Value to the Camera")]
    public bool SetMinY;
    public float YMinValue = 0;


    [Tooltip("Set a Maximum X Value to the Camera")]
    public bool SetMaxX;
    public float XMaxValue = 0;

    [Tooltip("Set a Minimum X Value to the Camera")]
    public bool SetMinX;
    public float XMinValue = 0;
    void FixedUpdate()
    {
        //I Will explain really shortly this cause it actually manage to
        //explain itself:

        //First we get our target position which will be our player's position
        Vector3 targetPos = player.position;


        //Then we check if MaxY and MinY are enabeled set the values to our y vector
        if (SetMinY && SetMaxY)
        {
            targetPos.y = Mathf.Clamp(player.position.y, YMinValue, YMaxValue);
        }
        //Then we check if  MinY are enabeled set the value to our y and set the maxY 
        //to have no limits so it will keep following our player
        else if (SetMinY)
        {
            targetPos.y = Mathf.Clamp(player.position.y, YMinValue, player.position.y);
        }
        //Then we check if  MaxY is enabeled set the value to our y and set the MinY 
        //to keep following our player
        else if (SetMaxY)
        {
            targetPos.y = Mathf.Clamp(player.position.y, player.position.y, YMaxValue);
        }



        //Then we check if MaxX and MinX are enabeled set the values to our y vector
        if (SetMinX && SetMaxX)
        {
            targetPos.x = Mathf.Clamp(player.position.x, XMinValue, XMaxValue);
        }
        //Then we check if  MinX are enabeled set the value to our y and set the maxX
        //to have no limits so it will keep following our player
        else if (SetMinX)
        {
            targetPos.x = Mathf.Clamp(player.position.x, XMinValue, player.position.x);
        }
        //Then we check if  MaxX is enabeled set the value to our y and set the MinX
        //to keep following our player
        else if (SetMaxX)
        {
            targetPos.x = Mathf.Clamp(player.position.x, player.position.x, XMaxValue);
        }

        //We keep our target position Z as is because it wont change
        targetPos.z = transform.position.z;

        //and set our position to refresh smoothly using the smooth time we set
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, SmoothTime);
    }


}
