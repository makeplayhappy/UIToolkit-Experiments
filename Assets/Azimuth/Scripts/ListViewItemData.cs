using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct ListViewItem{
    public string label;
    public string description;
    public string image;
    public string background;

}


[CreateAssetMenu(fileName = "new ListViewItemData", menuName = "ScriptableObjects/ListViewItemData", order = 30)]
public class ListViewItemData : ScriptableObject {   
    public List<ListViewItem> items;
}