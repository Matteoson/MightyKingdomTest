using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* PlayerMovement.cs - Touch Twin Stick Controls 
 * A movement script for Touch Twin Stick controls. 
 * Requires the asset "Joystick Pack" or something similar to get the input data
 * 
 * By Matthew Vecchio 24/1/19
 */
public class PlayerMovement : MonoBehaviour {

    [Tooltip("The area where the player will shoot from")]
    public GameObject shotSpawn; // the gameObject area to spawn a shoot
    [Tooltip("The bullet prefab")]
    public GameObject bullet;
    [Tooltip("The number of max bullets that can be fired at once")]
    public int MAX_BULLETS; // the Max Bullets that can be created
    [Tooltip("How fast the movement speed is for the character")]
    public float movementSpeed = 1000;
    [Tooltip("The link to the Left Joystick")]
    public Joystick leftJoystick;
    [Tooltip("The link to the Right Joystick")]
    public Joystick rightJoystick;

    private bool isShooting = false;

    private float step;
    public static int shotCount;   // this is static so other scripts can access it
    private float shotDelay;
    private Transform transform;
    private Rigidbody rb;
    private Vector3 fireDir;
    private Quaternion idleRot = new Quaternion();



    void Start () {
        transform = gameObject.GetComponent<Transform>();
        rb = gameObject.GetComponent<Rigidbody>();

    }


    void Update() {


        // check if the movement (left) joystick has been moved
        if (leftJoystick.Horizontal != 0 || leftJoystick.Vertical != 0 ) {
            
            rb.velocity = new Vector3(leftJoystick.Horizontal * step, rb.velocity.y, leftJoystick.Vertical * step); // turn the movement into velocity

            if (!isShooting) idleRot = Quaternion.LookRotation(rb.velocity); // if the character is not shooting update the idle rotation
        
        } else
        {
            // if there is no left Joystick movement halt the character
            rb.velocity = new Vector3(0, 0, 0); 
        }



        // check if the shooting (right) joystick has been moved
        if (rightJoystick.Horizontal != 0 || rightJoystick.Vertical != 0)
        {

            fireDir = new Vector3(rightJoystick.Horizontal * step, rb.velocity.y, rightJoystick.Vertical * step); // work out the fire direction vector 3
            idleRot = Quaternion.LookRotation(fireDir); // since the character is going to fire in the direction update the idle Rotation to match the firing direction
            fire();

        }


        // after the character shot delay is over allow the character to shoot again
        if (Time.time > shotDelay)
        {
            isShooting = false;
        }


        transform.rotation = idleRot; // update the characters rotation based on the idleRot

     

    }

    void fire()
    {
        // check if the character should fire (under MAX_BULLETS and after the shot delay)
        if (shotCount < MAX_BULLETS && shotDelay < Time.time)
        {
            shotCount++; // at a shot to the count
            isShooting = true; // set isShooting to true
            shotDelay = Time.time + 0.2f; // add the shot Delay (0.2 of a second) this could be a public variable
            Instantiate(bullet, shotSpawn.transform.position, transform.rotation); // spawn the bullet from the prefab
        }



    }

    void FixedUpdate()
    {
        step = movementSpeed * Time.fixedDeltaTime; // update the movements based on delta time

      

    }
}
