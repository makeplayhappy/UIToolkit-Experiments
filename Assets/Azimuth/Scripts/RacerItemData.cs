using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new RacerItemData", menuName = "ScriptableObjects/RacerItemData", order = 900)]
public class RacerItemData : ScriptableObject
{
    public string name;
    public string color;
    public float hoursTrained;
    public float topSpeed;

    public int lapsCompleted;
    public int racesEntered;
    public int racesCompleted;
    public int racesWon;
    public int bestPlacing;
    public int rank;
    public List<Achievements> achievements;

    public override string ToString(){
        return name + ", " + 
                color + ", " + 
                hoursTrained + ", " + 
                topSpeed + ", " + 
                rank + ", " + achievements.ToString();

    }


}
