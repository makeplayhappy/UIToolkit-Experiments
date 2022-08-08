using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Azimuth
{
    public class RacerList : VisualElement
    {
        // UxmlFactory and UxmlTraits a
        public new class UxmlFactory : UxmlFactory<RacerList, UxmlTraits> {}
        public new class UxmlTraits : VisualElement.UxmlTraits {}

        private List<string> items;
        private List<RacerItemData> listViewItemDataList;

        private VisualElement selectionDetails;
        private VisualElement trainingImage;
        private Label trainingName;
        private Label trainingDescription;
        private ListView listView;

        private RacerInfo infoPanel;

        public RacerList()
        {
            this.RegisterCallback<GeometryChangedEvent>(OnGeometryChange);
        }

        void OnGeometryChange(GeometryChangedEvent evt) {
            
            //Debug.Log("RacerList OnGeometryChange");


            //UIDocument ui_doc = GetComponent<UIDocument>();
            //VisualElement root = ui_doc.rootVisualElement;
            // borrowed from https://docs.unity3d.com/ScriptReference/UIElements.ListView.html

            listViewItemDataList = new List<RacerItemData>();
            listViewItemDataList.AddRange(Resources.LoadAll<RacerItemData>("Racers"));
            
            if( listViewItemDataList != null ){

                listView = this.Q<ListView>();

                infoPanel = this.Q<RacerInfo>();

            //    infoPanel.AddToClassList("off-right");


                listView.makeItem = MakeItem;//makeItem;
                listView.bindItem = BindItem;//bindItem;
                listView.itemsSource = listViewItemDataList;

                for(int i = 0; i < listViewItemDataList.Count; i++){
                    Debug.Log( "Racers count:" + i + ": " + listViewItemDataList[i].name );
                }

                // Callback invoked when the user double clicks an item
                listView.onItemsChosen += Debug.Log;
                // Callback invoked when the user changes the selection inside the ListView
                listView.onSelectionChange += ItemSelected;//Debug.Log;

                listView.style.flexGrow = 1.0f;
            }

            this.UnregisterCallback<GeometryChangedEvent>(OnGeometryChange);
        }

        private void ItemSelected( IEnumerable<object> selectedItems){
            

            //Debug.Log("RacerList Root " + this.Q<VisualElement>().name);

            foreach(RacerItemData itemData in selectedItems){
                //Debug.Log("Racer Selected " + itemData.name);
                infoPanel.SetRacer(itemData);

                infoPanel.style.translate = new Translate(0, 0);

                //"in-right"


            }
            


        }

        private void BindItem(VisualElement element, int index)
        {
            
            //(e as Label).text = items[i]
            
            var label = element.Q<Label>();
            RacerItemData itemData = listViewItemDataList[index];
            label.text = itemData.name;

            //Debug.Log("RacerList BindItem " + index + " " + itemData.name);
            
        }


        private VisualElement MakeItem() {
            // Create a row to hold a label and "-" button.
           // Debug.Log("RacerList Make Item ");

            var row = new VisualElement();
            row.style.flexDirection = FlexDirection.Row;
            row.style.justifyContent = Justify.SpaceBetween;
     
            // Create the label.
            var label = new Label("Custom Item");
            label.AddToClassList("custom-label");
            row.Add(label);

            //var button = new Button { text = ">", tooltip = "Remove this item from the list" };
            //row.Add(button);
     
            // Create the "-" button.
            /*
            var button = new Button { text = "-", tooltip = "Remove this item from the list" };
            button.RegisterCallback<ClickEvent>((evt) =>
            {
                VisualElement element = evt.target as VisualElement;
                if (element != null && element.userData is int index)
                {
                    m_ArrayProperty.DeleteArrayElementAtIndex(index);
                    m_SerializedObject.ApplyModifiedProperties();
                }
            });
            row.Add(button);
            */
     
            // Add the row and the item field editors to a bindable element container.
            var container = new BindableElement();
            container.Add(row);
            //container.Add(new TextField() { bindingPath = nameof(Item.StringValue) });
            //container.Add(new FloatField() { bindingPath = nameof(Item.FloatValue) });
     
            return container;
        }
    }
}
