using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* CameraTracker.cs
 * This Script is designed to go onto a camera in order to track a pubically set gameobject 
 * by Matthew Vecchio 24/01/2019
 * 
 * */
public class CameraTracker : MonoBehaviour {

    [Tooltip("the GameObject for the camera to track")]
    public GameObject trackingObject;
    private Vector3 offset;


	void Start ()
    {
        offset = transform.position - trackingObject.transform.position;
	}
	

	void Update ()
    {
        transform.position = trackingObject.transform.position + offset;	
	}
}
