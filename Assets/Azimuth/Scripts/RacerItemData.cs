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


}

public enum Achievements{
    EnterRace = 0, TrainBrain = 1,
    Bronze = 10, Silver = 11, Gold = 12,

    OneLap = 100, TenLap = 101, FiftyLap = 102, HundredLap = 103, 
    TwentySpeed = 200, ThirtySpeed = 201, FourtySpeed = 202, FiftySpeed = 203,
    
    OnePodium = 300, TwoPodium = 301, ThreePodium = 302, FivePodium = 303, TenPodium = 304,
    OneVictory = 401, TwoVictory = 402, ThreeVictory = 403, FiveVictory = 404, TenVictory = 405,

    OneSquashed = 500, TwoSquashed = 501, ThreeSquashed = 502, FiveSquashed = 503, TenSquashed = 504,

    BeatRocket = 1000, BeatBooster = 1001, BeatWeaver = 1002, 
    


}
