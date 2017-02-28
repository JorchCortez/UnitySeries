using UnityEngine;
using System.Collections;

[AddComponentMenu("Delta/Controllers/2D Player Controller")]
public class PlayerController2D : MonoBehaviour {
    [Header("2D Player Controller Script")]
    /*Setup Instructions!
     * This Code is created to make the Player move, You will need to have your player set
     * with a Box collider on the Upper Body and a Circle collider in the Bottom section of it
     * So the border of the Circle collider will be on the Player's feet.
     * Also you MUST have an empty object inside the Player and you can name it ground Point just to keep that 
     * in Mind (If you want to name it any other way, what ever, that's yours tho :V)
     * So Finally that empty Object is going to be placed in the very bottom of your character and once there
     * place it in the groundPoint Space in the Inspector.
     * 
     * dev: Jorge Cortez
     * Delta Softworks
     * contact: jacortez_94@hotmail.com
     * 5/12/2016
     * 
     */
     //Player Movement Informacion
    [Tooltip("Set the Player's Speed.")]
    public int moveSpeed;
    [Tooltip("Set Player's jump Height.")]
    public int JumpHeight;


    //Variables used to check wether if player is or isnt in the floor
    [Header("Floor locator")]
    [Tooltip("Place here the Gizmo to use as Floor Locator.")]
    public Transform groundPoint;
    [Tooltip("Set Gizmo's Radius (Pref. 0.02).")]
    public float radius;
    [Tooltip("Select the LayerMask where the Floor is located.")]
    public LayerMask groundMask;

    //IsGrounded variable as well as Player's Rigid Body
    bool isGrounded;
    Rigidbody2D PlayerBody;
    [HideInInspector]
    public float x, y , z;
    void Start () {
        //Set the PLayerBody Variable to get the information of its Rigid Body
        PlayerBody = GetComponent<Rigidbody2D>();
        x = GetComponent<Transform>().localScale.x;
        y = GetComponent<Transform>().localScale.y;
        z = GetComponent<Transform>().localScale.z;

    }
	

	void Update () {
        Vector2 moveDirection = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, PlayerBody.velocity.y);
        PlayerBody.velocity = moveDirection;

        isGrounded = Physics2D.OverlapCircle(groundPoint.position, radius, groundMask);

        if(Input.GetAxisRaw("Horizontal") == 1)
        {
            transform.localScale = new Vector3(x, y, z);
        }
        else if(Input.GetAxisRaw("Horizontal") == -1){
            transform.localScale = new Vector3(-x, y, -z);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            PlayerBody.AddForce(new Vector2(0, JumpHeight));

        }
    }


    //Set that If we get into a Mooving platform our player will become child of it,
    //so we will move together with the platform.
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "MovingPlatform")
        {
            transform.parent = other.transform;
        }
    }
    //Set that If we get out of the platform our player will no longer be its child,
    //just to avoid moving together with it.
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.tag == "MovingPlatform")
        {
            transform.parent = null;
        }
    }

    // This will be the Gizmo in charge of checking wether if the player is or not touching the floor.
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundPoint.position, radius);
    } 
}
