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

        private ListViewItemData listViewItemData;



        private VisualElement selectionDetails;
        private VisualElement trainingImage;
        private Label trainingName;
        private Label trainingDescription;
        private ListView listView;

        public TrainingType()
        {
            this.RegisterCallback<GeometryChangedEvent>(OnGeometryChange);
        }

        void OnGeometryChange(GeometryChangedEvent evt)
        {
            
            Debug.Log("TrainingTypeSelection OnGeometryChange");

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

            listViewItemData = Resources.Load<ListViewItemData>("Data/TrainingList");
            

            Debug.Log( listViewItemData );

            //Func<VisualElement> makeItem = () => new Label();
            //Action<VisualElement, int> bindItem = (e, i) => (e as Label).text = items[i];

            if( listViewItemData != null ){

                listView = this.Q<ListView>();

                selectionDetails = this.Q<VisualElement>("selection-details");
                trainingImage = this.Q<VisualElement>("training-image");
                trainingName = this.Q<Label>("training-name");
                trainingDescription = this.Q<Label>("training-description");

                Debug.Log(listView);

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
            foreach(ListViewItem itemData in selectedItems){
                Debug.Log("Item Selected " + itemData.label);

                trainingName.text = itemData.label;
                trainingDescription.text = itemData.description;
//portraitImage.style.backgroundImage
// Resources.Load<Texture2D >("Data/TrainingList")
                selectionDetails.style.backgroundImage = new StyleBackground( Resources.Load<Texture2D>(itemData.background) );


            }
            


        }

        private void BindItem(VisualElement element, int index)
        {
            
            //(e as Label).text = items[i]

            var label = element.Q<Label>();
            ListViewItem itemData = listViewItemData.items[index];
            label.text = itemData.label;
            
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
/*

<EletricAzimuth.TrainingTypeSelection name="training-selection" style="flex-grow: 1; background-color: rgba(0, 0, 0, 0);">
    <ui:VisualElement name="wrapper" style="flex-grow: 1; background-color: rgba(0, 0, 0, 0); width: 100%; height: 100%;">
        <ui:ListView focusable="true" show-border="false" fixed-item-height="44" name="training-type" style="width: 100%; height: auto; min-height: 200px; max-height: 500px; display: flex;" />
    </ui:VisualElement>

    <ui:VisualElement name="selection-details" class="col-2" style="flex-wrap: nowrap; background-color: rgb(82, 137, 133); width: 100%; flex-direction: row; align-items: flex-start; height: 40%; position: relative; bottom: 0; min-height: 150px; background-image: resource(&apos;Images/placeholder-image&apos;);">
        
        <ui:VisualElement class="col" style="flex-grow: 1; background-color: rgba(0, 0, 0, 0); flex-wrap: nowrap; flex-direction: column; align-items: flex-start; justify-content: flex-end; align-self: flex-start; padding-left: 10px; padding-right: 0; padding-top: 10px; padding-bottom: 0;">
            <ui:Label tabindex="-1" text="Training Name" display-tooltip-when-elided="true" name="training-name" class="h2" style="white-space: normal; align-self: auto; align-items: flex-start; width: 100%; margin-left: 0; margin-top: 0;" />
            <ui:Label tabindex="-1" text="Details all about what this is, possibly spanning three lines of maybe even four" display-tooltip-when-elided="true" name="training-description" style="white-space: normal; width: 100%; margin-left: 0;" />
        </ui:VisualElement>
        
        <ui:VisualElement name="training-image" class="col" style="width: 50%; height: 100%; background-image: resource(&apos;Images/placeholder-image&apos;);" />
    </ui:VisualElement>
</EletricAzimuth.TrainingTypeSelection>

*/