using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Azimuth
{
    public class TrainingType : VisualElement
    {
        // UxmlFactory and UxmlTraits a
        public new class UxmlFactory : UxmlFactory<TrainingType, UxmlTraits> {}
        public new class UxmlTraits : VisualElement.UxmlTraits {}

        private List<string> items;

        private TrainingListData listViewItemData;

        //public List<Achievements> playerAchievements;

        public PlayerDataCache playerDataCache;



        private VisualElement selectionDetails;
        private VisualElement trainingImage;
        private Label trainingName;
        private Label trainingDescription;
        private ListView listView;

        public TrainingType()
        {
            listViewItemData = Resources.Load<TrainingListData>("Data/TrainingList");
            playerDataCache = Resources.Load<PlayerDataCache>("Racers/PlayerDataCache");

            for(int i = 0; i < listViewItemData.items.Count;i++){
                TrainingListItem item = listViewItemData.items[i];

                item.isEnabled = false;

                if( item.achievementRequired == null || item.achievementRequired == Achievements.None){
                    item.isEnabled = true;
                }else if(playerDataCache != null && playerDataCache.racer != null && playerDataCache.racer.achievements.Contains( item.achievementRequired ) ){
                    item.isEnabled = true;
                }
                listViewItemData.items[i] = item;

                //Debug.Log(item);

            }

            this.RegisterCallback<GeometryChangedEvent>(OnGeometryChange);
        }

        void OnGeometryChange(GeometryChangedEvent evt)
        {
            
            //Debug.Log("TrainingTypeSelection OnGeometryChange");

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

           //listViewItemData = Resources.Load<TrainingListData>("Data/TrainingList");
            

            //Debug.Log( listViewItemData );

            //Func<VisualElement> makeItem = () => new Label();
            //Action<VisualElement, int> bindItem = (e, i) => (e as Label).text = items[i];

            if( listViewItemData != null ){

                listView = this.Q<ListView>();

                selectionDetails = this.Q<VisualElement>("selection-details");
                trainingImage = this.Q<VisualElement>("training-image");
                trainingName = this.Q<Label>("training-name");
                trainingDescription = this.Q<Label>("training-description");

                //Debug.Log(listView);

                listView.makeItem = MakeItem;//makeItem;
                listView.bindItem = BindItem;//bindItem;
                listView.itemsSource = listViewItemData.items;

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


            foreach(TrainingListItem itemData in selectedItems){
                //Debug.Log("Item Selected " + itemData.label);


                trainingName.text = itemData.label;
                
                trainingImage.style.backgroundImage = new StyleBackground( Resources.Load<Texture2D>(itemData.image) );
                selectionDetails.style.backgroundImage = new StyleBackground( Resources.Load<Texture2D>(itemData.background) );
                if( itemData.isEnabled){
                    trainingDescription.text = itemData.description;
                }else{
                    trainingDescription.text = itemData.lockedDescription;
                }

            }
            


        }

        private void BindItem(VisualElement element, int index)
        {
            
            //(e as Label).text = items[i]
            TrainingListItem itemData = listViewItemData.items[index];

            var label = element.Q<Label>(name:"list-text");

            if( label != null){
                
                label.text = itemData.label;
            }
            
            

//:disabled 	The Element is set to enabled == false.
//:enabled 	The Element is set to enabled == true.
            element.SetEnabled( itemData.isEnabled );
            element.pickingMode = PickingMode.Ignore;
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


        private VisualElement MakeItem() {
        /*    
            // Create a row to hold a label and "-" button.
            var row = new VisualElement();
            row.style.flexDirection = FlexDirection.Row;
            row.style.justifyContent = Justify.SpaceBetween;
     
            // Create the label.
            var label = new Label("Custom Item");
            label.AddToClassList("custom-label");
            row.Add(label);

            var button = new Button { text = ">", tooltip = "Remove this item from the list" };
            row.Add(button);
        */
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

            var row = new LockableListItem();
            row.style.flexDirection = FlexDirection.Row;
            row.style.justifyContent = Justify.SpaceBetween;

            // Add the row and the item field editors to a bindable element container.
            var container = new BindableElement();
            container.Add(row);
            //container.Add(new TextField() { bindingPath = nameof(Item.StringValue) });
            //container.Add(new FloatField() { bindingPath = nameof(Item.FloatValue) });
     
            return container;
        }
    }
}
