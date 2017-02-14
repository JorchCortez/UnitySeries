using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class crateMove : MonoBehaviour {

    //Where is it gonna move towards?
    public Vector3 Myvector3;
    //Rigid body
    Rigidbody2D myrb2d;
    

	// Use this for initialization
	void Start () {
        //Place our rigid body 2d component into the myrb2d 
        //variable so we can interact with it
        myrb2d = GetComponent<Rigidbody2D>();
        //Sets the velocity to be equals to the
        //speed you place in the axis you select
        myrb2d.velocity = Myvector3;

	}
}
