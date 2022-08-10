using UnityEngine;
using UnityEngine.UIElements;
using System.Collections;
using System.Collections.Generic;
using UnityAtoms;

namespace Azimuth {
    // Derives from BaseField<bool> base class. Represents a container for its input part.
    public class ActionButton : Button {

        public UIAction uiAction { get; set; }
        public UIActionVariable uiActionVar { get; set; }

        public new class UxmlFactory : UxmlFactory<ActionButton, UxmlTraits> { }


        public new class UxmlTraits : Button.UxmlTraits {
            UxmlEnumAttributeDescription<UIAction> m_Action = new UxmlEnumAttributeDescription<UIAction> { name = "ui-action", defaultValue = UIAction.None };
     
            public override IEnumerable<UxmlChildElementDescription> uxmlChildElementsDescription {
                get { yield break; }
            }

            //Here we juggle the attribute value stored in the attribute "bag" to the local property
            public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc) {
                base.Init(ve, bag, cc);
                ActionButton aButton = ve as ActionButton;
                aButton.Clear();
                aButton.uiAction = m_Action.GetValueFromBag(bag, cc);

            }
        }

        //this overrides the "default" actions - allow them to be stopped using prevent default
        protected override void ExecuteDefaultActionAtTarget(EventBase evt) {
            // Do not forget to call the base function.
            base.ExecuteDefaultActionAtTarget(evt);
            
            // other event examples: }else if( == MouseDownEvent.TypeId() ... MouseUpEvent.TypeId() ClickEvent PointerDownEvent etc..
            // https://docs.unity3d.com/Manual/UIE-Events-Reference.html
            //Debug.Log( evt.eventTypeId );
            if (evt.eventTypeId == ClickEvent.TypeId()){// PointerDownEvent.TypeId()){
                if( uiActionVar != null){
                    Debug.Log("Setting to " + this.uiAction);
                    uiActionVar.Value = this.uiAction;
                }else{
                    Debug.Log("UI Var not set");
                }
                //Debug.Log("ExecuteDefaultActionAtTarget ClickEvent " + this.uiAction);
            }


        }

        
    }
}
