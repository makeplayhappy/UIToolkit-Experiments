using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using MyUILibrary;
public class SetupActionButtons : MonoBehaviour
{
    public UIDocument document;
    protected VisualElement documentRoot;
    void Awake() {
        documentRoot = document.rootVisualElement;

            // Register callbacks to trigger UI Actions (picked up by UIActions)
    //documentRoot.Q<Button>(name: "quit").clicked += () => DoUIAction(UIAction.Quit);

    //multiple elements need the query + foreach to assign callback
    //documentRoot.Query<ActionButton>(name: "options").ForEach( e => e.clicked += () => DoUIAction(UIAction.GlobalOptions) ); 
        documentRoot.Query<MyUILibrary.ActionButton>().ForEach( e => e.clicked += () => Debug.Log("action clicked") ); 

        // redBox.RegisterCallback<PointerDownEvent>(OnPointerDown, TrickleDown.TrickleDown);

// https://docs.unity3d.com/ScriptReference/UIElements.Button.html
// https://github.com/Unity-Technologies/UIElementsExamples/blob/master/Assets/Examples/Editor/E20_DragAndDrop.cs

    //racer-list
            



            
    }

    public void OnPointerDown( PointerDownEvent evt ){
        Debug.Log("PointerDownEvent");
    }


}
