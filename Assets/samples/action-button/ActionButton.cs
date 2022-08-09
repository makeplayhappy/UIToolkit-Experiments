using UnityEngine;
using UnityEngine.UIElements;
using System.Collections;
using System.Collections.Generic;

namespace MyUILibrary
{
    // Derives from BaseField<bool> base class. Represents a container for its input part.
    public class ActionButton : Button {

        public UIAction enumAttr { get; set; }

        public new class UxmlFactory : UxmlFactory<ActionButton, UxmlTraits> { }

        ///public new class UxmlTraits : BaseFieldTraits<bool, UxmlBoolAttributeDescription> { }

        public new class UxmlTraits : Button.UxmlTraits
        {
            UxmlEnumAttributeDescription<UIAction> m_Enum = new UxmlEnumAttributeDescription<UIAction> { name = "enum-attr", defaultValue = UIAction.None };
     
            public override IEnumerable<UxmlChildElementDescription> uxmlChildElementsDescription
            {
                get { yield break; }
            }
     
            public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
            {
                base.Init(ve, bag, cc);
                var ate = ve as ActionButton;
     
                ate.Clear();
          
                ate.enumAttr = m_Enum.GetValueFromBag(bag, cc);
                /* -- this adds in a new EnumField into the element - we dont want this we just want to retreive the action on click
                var en = new EnumField("Enum");
                en.Init(m_Enum.defaultValue);
                en.value = ate.enumAttr;
                ate.Add(en);
                */
            }
        }

        
    }
}
