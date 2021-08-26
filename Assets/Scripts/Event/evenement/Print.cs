using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Print : MonoBehaviour
{
    // Event
	public Declancheur decl;
    void Update(){
    	if(decl.GetActive()){
    		decl.ResetActive();
    		Debug.Log("event 1 Declanché");
    	}
    }
}
