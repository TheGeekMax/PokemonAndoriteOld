using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "status", menuName = "pokemon/Attack", order = 1)]
public class Attack : ScriptableObject{
	public string nom;
	public Type type;

	public int precision;
	public int puissance;
	public int pp;
}
