using UnityEngine;
using System.Collections;


[AddComponentMenu("Delta/2D Tools/Respawner 2D")]
public class Respawner : MonoBehaviour {
    /*
     * Respawner Script 2D
     * This is thinked and supposed to be easy, so first of all we're gonna make the following, 
     * We will have an script so that if you fall or happen to collide with any collider you label as destroy
     * or so, i dont care the name you use, you will be automatically transported to the respawn point.
     * Later on i will make the code so if you catch a check point it will be your new respawn point
     * but untill then forget about it.
     * 
     * This Script MUST be placed in the player.
     * 
     * 
     * Enjoy the code and Good luck!!
     * 
     * Dev: Jorge Cortez
     * Last edited on: Thursday 1/5/2017      
     */
   [Header("Respawn Properties")]
   [Tooltip("Place in here the main Respawn Point you want to use")]
    public GameObject RespawnPoint;

    [Tooltip("If True you can add Triggers in the game with checkPoint tag to modify the Checkpoint")]
    public bool haveCheckpoints;

    //private GameObject player;

    [Header("Destroyer/Killer Properties")]
    [Tooltip("Write here the tag of the destroyer you will use.")]
    public string Destroyer;
   

    void OnTriggerEnter2D(Collider2D other)
    {
        //If we collide with a Destroyer we will be transported directly to our last checkpoint saved.
        if (other.gameObject.tag == Destroyer)
        {
            this.transform.position = RespawnPoint.transform.position;
        }

        //If have checkpoints is true every time you pass over a checkpoint the checkpoint will refresh
        //but only with a new checkpoint you must know how this works.
        if(haveCheckpoints == true)
        {
            if (other.gameObject.tag == "CheckPoint" || other.gameObject.tag == "checkPoint" || other.gameObject.tag == "checkpoint")
            {
                RespawnPoint = other.gameObject;
                other.GetComponent<BoxCollider2D>().enabled = false;
            }
        }

    }
}