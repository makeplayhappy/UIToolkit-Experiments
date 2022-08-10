using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using MyUILibrary;
using UnityAtoms;
public class SetupActionButtons : MonoBehaviour
{
    public UIDocument document;
    public UIActionVariable uiActionVar;

    protected VisualElement documentRoot;
    void Awake() {
        documentRoot = document.rootVisualElement;

            // Register callbacks to trigger UI Actions (picked up by UIActions)
    //documentRoot.Q<Button>(name: "quit").clicked += () => DoUIAction(UIAction.Quit);

    //multiple elements need the query + foreach to assign callback
    //documentRoot.Query<ActionButton>(name: "options").ForEach( e => e.clicked += () => DoUIAction(UIAction.OptionsMenu) ); 
        //documentRoot.Query<MyUILibrary.ActionButton>().ForEach( element => element.clicked += () => Debug.Log("action clicked") ); 
        //documentRoot.Query<MyUILibrary.ActionButton>().ForEach( element => element.RegisterCallback<PointerDownEvent>(OnPointerDown, TrickleDown.TrickleDown) );
        //documentRoot.Query<MyUILibrary.ActionButton>().ForEach( element => element.RegisterCallback<ClickEvent>(OnClick, TrickleDown.TrickleDown) );

        documentRoot.Query<MyUILibrary.ActionButton>().ForEach( element => element.uiActionVar = uiActionVar );




        // element.RegisterCallback<ClickEvent>(evt => Debug.Log("Clicked Event"));

        // element.RegisterCallback<PointerDownEvent>(OnPointerDown, TrickleDown.TrickleDown);

// https://docs.unity3d.com/ScriptReference/UIElements.Button.html
// https://github.com/Unity-Technologies/UIElementsExamples/blob/master/Assets/Examples/Editor/E20_DragAndDrop.cs

    //racer-list
            



            
    }
/*
    public void OnClick( ClickEvent evt ){

        ActionButton button = (ActionButton)evt.target;
        Debug.Log("ClickEvent ActionButton:" + button.uiAction);
    }

    public void OnPointerDown( PointerDownEvent evt ){

        ActionButton button = (ActionButton)evt.target;

        Debug.Log("PointerDownEvent ActionButton:" + button.uiAction);
    }
*/

}
