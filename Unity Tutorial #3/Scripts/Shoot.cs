using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    //Bullet prefab
    public GameObject Bullet;

    //Spawn point
    public GameObject SpawnPoint;

    //Speed
    public float ShootSpeed = 200;

    //Bullet holder
    GameObject Clone;


	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space)) {
            //print("Bullet has been shoot");
            //instantiate the projectile at the spownpoint position
            Clone = Instantiate(Bullet, SpawnPoint.transform.position, SpawnPoint.transform.rotation);

            //Adding the force to our bullet
            Rigidbody CloneRb = Clone.GetComponent<Rigidbody>();
            CloneRb.AddForce(Clone.transform.forward * ShootSpeed);
            
        }

    }
}
