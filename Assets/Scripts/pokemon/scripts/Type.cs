using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "type", menuName = "pokemon/Type", order = 1)]
public class Type : ScriptableObject{
	public new string name;
	public Sprite image;
	public StrengthType[] strengths;
}


[System.Serializable]
public class StrengthType{
	public Type type;
	public float strength;
	public StrengthType(Type type_,float strength_){
		type = type_;
		strength = strength_;
	}
}
