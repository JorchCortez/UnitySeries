using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationScript : MonoBehaviour 
{
    //Declare our variables
    public float x;
    public float y;
    public float z;
	
	// Update Method is called once per frame
	void Update () {
        //transforms the object's rotation to the axis you preffer 
        transform.Rotate(new Vector3(x, y, z) * Time.deltaTime);
	}
}
