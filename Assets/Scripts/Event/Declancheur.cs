using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Declancheur : MonoBehaviour
{
    // declancheur
    bool active = false;
    bool exec = false;
    Data dt;

    public void SetData(Data newdt){
        dt = newdt;
    }

    public Data GetData(){
        return dt;
    }


    public bool GetActive(){
    	return active;
    }

    public void SetActive(){
    	active = true;
    }

    public void ResetActive(){
    	active = false;
    }

    

    public bool GetRunning(){
        return exec;
    }

    public void SetRunning(){
        exec = true;
    }

    public void ResetRunning(){
        exec = false;
    }
}
