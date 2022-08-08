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

        void OnGeometryChange(GeometryChangedEvent evt)
        {
            
            Debug.Log("RacerList OnGeometryChange");


            //UIDocument ui_doc = GetComponent<UIDocument>();
            //VisualElement root = ui_doc.rootVisualElement;
            // borrowed from https://docs.unity3d.com/ScriptReference/UIElements.ListView.html
/*
            const int itemCount = 35;
            var items = new List<string>(itemCount);
            for (int i = 1; i <= itemCount; i++)
                items.Add(i.ToString());
*/
            //items = new List<string>(){"Track World","Infinite Track Run","Chained to a rock","Chase Wally","Rumble in the Jungle"};

            //listViewItemData = Resources.Load<RacerItemData>("Racers");
            listViewItemDataList = new List<RacerItemData>();
            listViewItemDataList.AddRange(Resources.LoadAll<RacerItemData>("Racers"));
            
            

            //Func<VisualElement> makeItem = () => new Label();
            //Action<VisualElement, int> bindItem = (e, i) => (e as Label).text = items[i];

            if( listViewItemDataList != null ){

                listView = this.Q<ListView>();

                infoPanel = this.Q<RacerInfo>();

/*
                selectionDetails = this.Q<VisualElement>("selection-details");
                trainingImage = this.Q<VisualElement>("training-image");
                trainingName = this.Q<Label>("training-name");
                trainingDescription = this.Q<Label>("training-description");

                Debug.Log(listView);
*/
                listView.makeItem = MakeItem;//makeItem;
                listView.bindItem = BindItem;//bindItem;
                listView.itemsSource = listViewItemDataList;

                for(int i = 0; i < listViewItemDataList.Count; i++){
                    Debug.Log( "Racers count:" + i + ": " + listViewItemDataList[i].name );
                }

                //Debug.Log( "Setting List view source:" );

                //listView.selectionType = SelectionType.Multiple;

                // Callback invoked when the user double clicks an item
                listView.onItemsChosen += Debug.Log;
                // Callback invoked when the user changes the selection inside the ListView
                listView.onSelectionChange += ItemSelected;//Debug.Log;

                listView.style.flexGrow = 1.0f;
            }

            /*
            musicToggle = this.Q<Toggle>("music-toggle");
            bool muteMusic = PlayerPrefs.GetInt(PlayerPrefsMuteMusicKey, 0) == 0;
            musicToggle?.SetValueWithoutNotify(!muteMusic);
            SetMuteMusic(muteMusic);
            musicToggle?.RegisterValueChangedCallback(e => OnMusicToggle(e));

            speedSlider = this.Q<SliderInt>("speed-slider");
            speedValue = this.Q<Label>("speed-value-label");
            int timeScale = (int)Mathf.Round(Time.timeScale);

            // Capping (only matters in the Editor where the time scale can be changed on the project properties
            // but we're being safe).
            if (timeScale > 3)
                timeScale = 3;
            else if (timeScale < 1)
                timeScale = 1;

            if (speedValue != null)
            {
                speedValue.text = timeScale.ToString();
                speedSlider.value = timeScale;
                speedSlider.RegisterValueChangedCallback(e => OnSpeedSliderChanged(e.newValue));
            }*/

            this.UnregisterCallback<GeometryChangedEvent>(OnGeometryChange);
        }

        private void ItemSelected( IEnumerable<object> selectedItems){
            

            Debug.Log("RacerList Root " + this.Q<VisualElement>().name);

            foreach(RacerItemData itemData in selectedItems){
                Debug.Log("Racer Selected " + itemData.name);
                infoPanel.SetRacer(itemData);

               // trainingName.text = itemData.name;
               // trainingDescription.text = itemData.description;
               // selectionDetails.style.backgroundImage = new StyleBackground( Resources.Load<Texture2D>(itemData.background) );


            }
            


        }

        private void BindItem(VisualElement element, int index)
        {
            
            //(e as Label).text = items[i]
            
            var label = element.Q<Label>();
            RacerItemData itemData = listViewItemDataList[index];
            label.text = itemData.name;

            Debug.Log("RacerList BindItem " + index + " " + itemData.name);
            
            // Assign the array index to the user data of the "-" button.
            /*
            var button = element.Q<Button>();
            if (button != null)
            {
                button.userData = index;
            }
     
            // Find the first bindable element.
            var field = element as IBindable;
            if (field == null)
            {
                field = (IBindable)element.Query()
                    .Where(x => x is IBindable)
                    .First();
            }
     
            // Bind the list view source element to the visual element.
            var itemProp = (SerializedProperty)m_ItemListView.itemsSource[index];
            field.bindingPath = itemProp.propertyPath;
            element.Bind(itemProp.serializedObject);*/
        }


        private VisualElement MakeItem()
        {
            // Create a row to hold a label and "-" button.
            Debug.Log("RacerList Make Item ");

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
