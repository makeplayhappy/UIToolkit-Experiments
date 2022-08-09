using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct TrainingListItem{
    public string label;
    public string description;
    public string lockedDescription;
    public string image;
    public string background;
    public Achievements achievementRequired;
    public bool isEnabled;

    public override string ToString(){
        return label + ", " + 
                description + ", " + 
                lockedDescription + ", " + 
                image + ", " + 
                background + ", " + achievementRequired.ToString();

    }



}


[CreateAssetMenu(fileName = "new TrainingListData", menuName = "ScriptableObjects/TrainingListData", order = 30)]
public class TrainingListData : ScriptableObject {   
    public List<TrainingListItem> items;
}