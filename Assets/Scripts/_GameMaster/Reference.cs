using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Reference : MonoBehaviour
{
    public static Reference instance;

    //references utiles pour Player
    public Transform cam;
	public Tilemap collisionTile;

    void Awake(){
    	if(!instance){
    		instance = this;
    	}
    }


}
