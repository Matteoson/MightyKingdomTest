using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* Boundary.cs
*  This script destroys anything Gameobject with a collider that leaves the field. 
*  it also reduced the shotCount of the player which can be taken out
* 
* By Matthew Vecchio 24/1/19
*/
public class Boundary : MonoBehaviour {
          
    void OnTriggerExit(Collider other)
    {

            PlayerMovement.shotCount--;
            Destroy(other.gameObject);
  

    }

}
