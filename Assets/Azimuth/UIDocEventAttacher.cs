using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIDocEventAttacher : MonoBehaviour
{
    private VisualElement root;
    private Button m_Button;

    private int m_ButtonClickCount = 0;
    // https://blog.unity.com/technology/ui-toolkit-at-runtime-get-the-breakdown

    //TODO - add a foreach and a test onclick to link the button name to a UnityEvent 
    private void OnEnable() {

        UIDocument ui_doc = GetComponent<UIDocument>();
        root = ui_doc.rootVisualElement;
        //m_Button = root.Q<Button>(name: "TopButton");

        m_Button = root.Q<Button>(className: "azimuth-button");   
        //.Q<Button>(null, "number-button");
    // Iterate through buttons
        //buttons.ForEach(SetupButton);

        m_Button.clickable.clickedWithEventInfo += OnButtonClicked;
        
    }

    private void OnDestroy() {

       m_Button.clickable.clickedWithEventInfo -= OnButtonClicked;
       //m_Toggle.UnregisterValueChangedCallback(OnToggleValueChanged);
   }
 
   private void OnButtonClicked( EventBase evt) {
       m_ButtonClickCount++;
       Debug.Log("Clicked " + m_ButtonClickCount + " times");
       Button button = (Button)evt.target;
       Debug.Log( evt.target ); 
       Debug.Log( button.name );


       //m_Label.text = m_ButtonClickCount.ToString();
   }
}
