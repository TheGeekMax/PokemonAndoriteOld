using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data{
    // Start is called before the first frame update
    public int x,y,orientation;
    public bool usePressed;
    public Data(int x_,int y_,int or,bool useP){
    	x = x_;
    	y = y_;
    	orientation = or;
    	usePressed = useP;
    }
}
