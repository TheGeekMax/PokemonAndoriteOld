using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystem : MonoBehaviour
{
    public static EventSystem instance;

    public GameObject eventParent;

    void Awake(){
    	// Debug.Log("hey");
    	if(!instance){
    		instance = this;
    	}
    }

    public void SendEvent(Data dt){
    	Declancheur[] childs = eventParent.GetComponentsInChildren<Declancheur>();
    	foreach (Declancheur child in childs){
    		child.SetData(dt);
    		child.SetRunning();
    		//Debug.Log("child running");
    	}
    }
}
