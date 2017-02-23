using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLifetime : MonoBehaviour {

    //Destroy method
    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
