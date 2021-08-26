using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour{	
	bool colliding = false;
    // Start is called before the first frame update

	public bool IsColliding(){
		return colliding;
	}

    void OnTriggerEnter2D(Collider2D other){
        colliding = true;
    }

    void OnTriggerExit2D(Collider2D other){
        colliding = false;
    }
}
