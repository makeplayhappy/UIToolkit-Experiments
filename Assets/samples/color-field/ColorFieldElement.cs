using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;    

namespace Picking
{
    public class ColorFieldElement : VisualElement
    {
        public string colorAttr { get; set; }
        public new class UxmlFactory : UxmlFactory<ColorFieldElement, UxmlTraits> { }
        public new class UxmlTraits : VisualElement.UxmlTraits
        { 
            UxmlStringAttributeDescription m_Color = new UxmlStringAttributeDescription { name = "color-attr", defaultValue = "ffffff" };
            // UxmlEnumAttributeDescription
            public override IEnumerable<UxmlChildElementDescription> uxmlChildElementsDescription
            {
                get { yield return new UxmlChildElementDescription(typeof(VisualElement)); }
            }
     
            public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
            {
                base.Init(ve, bag, cc);
                var ate = ve as ColorFieldElement;
     
                ate.Clear();

                ate.colorAttr = m_Color.GetValueFromBag(bag, cc);
                string col = "#" + ate.colorAttr;
                Color newCol;
                if (! ColorUtility.TryParseHtmlString(col, out newCol) ){
                    newCol = Color.white;
                }
                
                StyleColor styleColor = new StyleColor(newCol);
                VisualElement vis_el = new VisualElement(){style = {height = 50, width = 50, backgroundColor = styleColor}};
                ate.Add( vis_el );
     
            }
        }
    }
}