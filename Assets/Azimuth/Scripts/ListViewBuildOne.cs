using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

//using UnityEditor;


using System;


public class ListViewBuildOne : MonoBehaviour
{
    // Start is called before the first frame update
    void Start(){

        UIDocument ui_doc = GetComponent<UIDocument>();
        VisualElement root = ui_doc.rootVisualElement;
/*
        const int itemCount = 50;
        var items = new List<string>(itemCount);
        for (int i = 1; i <= itemCount; i++)
            items.Add(i.ToString());
        Func<VisualElement> makeItem = () => new Label();
        Action<VisualElement, int> bindItem = (e, i) => (e as Label).text = items[i];
        var listView = root.Q<ListView>();
        listView.makeItem = makeItem;
        listView.bindItem = bindItem;
        listView.itemsSource = items;
        listView.selectionType = SelectionType.Multiple;

        // Callback invoked when the user double clicks an item
        listView.onItemsChosen += Debug.Log;
        // Callback invoked when the user changes the selection inside the ListView
        listView.onSelectionChange += Debug.Log;
*/
/*
        var dropdown = root.Q<DropdownField>("colorselect");  
        dropdown.choices.Clear();
        

        List<string> color_choices = new List<string>(){"0d6efd","6610f2","6f42c1","d63384","dc3545","fd7e14","ffc107","198754","20c997","0dcaf0"}; 
        dropdown.choices = color_choices;
        dropdown.index = 3;
*/
        var dropdown = root.Q<EnumField>("enumcolor"); 
        dropdown.RegisterValueChangedCallback((evt)=>{
            Debug.Log($"The color enum value has changed to {evt.newValue}.");
        });

/*
        if (ColorUtility.TryParseHtmlString(htmlValue, out newCol))
            property.colorValue = newCol;*/

    }

    // Update is called once per frame
    
}


enum raceColors{
    yellow,orange,red,purple,blue,green,black,white
}


