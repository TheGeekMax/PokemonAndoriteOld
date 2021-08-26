using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilisationNormal : MonoBehaviour
{
    // detecteur
    public Declancheur decl;
    Transform trs;
    bool temporisateur;

    void Start(){
        trs = gameObject.GetComponent<Transform>();
    }

    Vector2 GetCoors(){
    	float x = trs.localPosition.x;
    	float y = trs.localPosition.y;
		return new Vector2(x,y);
    }

    public void Execute(Data dt){
        int x = 0 , y = 0;
        switch(dt.orientation){
            case 0:
            y = 1;
            break;
            case 1:
            x = 1;
            break;
            case 2:
            y = -1;
            break;
            case 3:
            x = -1;
            break;
        }
        Vector2 tempCoors = new Vector2(dt.x+x,dt.y+y);
    	Vector2 evntCoors = GetCoors();
        if(dt.usePressed && !temporisateur){
        	if(tempCoors.x == evntCoors.x && tempCoors.y == evntCoors.y){
        		temporisateur = true;
        		decl.SetActive();
        	}
        }else if(!dt.usePressed && temporisateur){
            temporisateur = false;
        }
    }

    void Update(){
        if(decl.GetRunning()){
            decl.ResetRunning();
            Data curData = decl.GetData();
            Execute(curData);
        }
    }
}
