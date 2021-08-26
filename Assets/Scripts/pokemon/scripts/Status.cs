using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "status", menuName = "pokemon/Status", order = 1)]
public class Status : ScriptableObject{
    public new string name;
    public Sprite affichage;
    public Stat[] stats;
    public IgStat[] igStats;
}
