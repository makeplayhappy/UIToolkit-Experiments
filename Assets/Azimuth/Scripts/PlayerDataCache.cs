using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is used at runtime to hold a reference to all the current player data, not trustworthy but better than passing around singletons!
[CreateAssetMenu(fileName = "new PlayerDataCache", menuName = "ScriptableObjects/PlayerDataCache", order = 910)]
public class PlayerDataCache : ScriptableObject {
    public RacerItemData racer;
    public int coins;
}