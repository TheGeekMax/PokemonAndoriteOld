using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionColliderBehaviour : MonoBehaviour{
    public PlayerCollider top;
    public PlayerCollider right;
    public PlayerCollider bottom;
    public PlayerCollider left;

    public bool IsColliding(int h,int v){
    	int or = 0;
    	if(v == 1){
    		or = 0;
    	}
    	if(v == -1){
    		or = 2;
    	}

    	if(h == 1){
    		or = 1;
    	}
    	if(h == -1){
    		or = 3;
    	}
    	switch(or){
    		case 0:

    			return top.IsColliding();
    		case 1:

    			return right.IsColliding();
    		case 2:

    			return bottom.IsColliding();
    		case 3:

    			return left.IsColliding();
    	}
    	return true;
    } 
}
