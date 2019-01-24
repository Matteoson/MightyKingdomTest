using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* BulletMovement.cs  
*  This manages a bullet's movement, speed and lifespan
* 
* 
* By Matthew Vecchio 24/1/19
*/
public class BulletMovement : MonoBehaviour {

    [Tooltip("the speed of the bullet")]
    public float speed;
    public float bulletDeathTimeAmount;
    private float bulletDeathTime;

	// Use this for initialization
	void Start () {
        bulletDeathTime = Time.time + bulletDeathTimeAmount;
     
      
	}
	
	// Update is called once per frame
	void Update () {

        if (bulletDeathTime < Time.time)
        {
            PlayerMovement.shotCount--;
            Destroy(gameObject);

        }
        transform.Translate(Vector3.forward * speed * Time.fixedDeltaTime);
    }
}
