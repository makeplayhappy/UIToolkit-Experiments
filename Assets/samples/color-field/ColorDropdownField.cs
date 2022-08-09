// Unity C# reference source
// Copyright (c) Unity Technologies. For terms of use, see
// https://unity3d.com/legal/licenses/Unity_Reference_Only_License

using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;    

namespace Picking
{

    /// <summary>
    /// A control that allows the user to pick a choice from a list of options.
    /// </summary>
    public class ColorDropdownField : PopupField<string>
    {
        /// <summary>
        /// Instantiates a <see cref="ColorDropdownField"/> using the data read from a UXML file.
        /// </summary>
        public new class UxmlFactory : UxmlFactory<ColorDropdownField, UxmlTraits> {}

        /// <summary>
        /// Defines <see cref="UxmlTraits"/> for the <see cref="ColorDropdownField"/>.
        /// </summary>
        public new class UxmlTraits : BaseField<string>.UxmlTraits
        {
            UxmlIntAttributeDescription m_Index = new UxmlIntAttributeDescription { name = "index" };
            UxmlStringAttributeDescription m_Choices = new UxmlStringAttributeDescription() { name = "choices" };


            //UxmlStringAttributeDescription m_Color = new UxmlStringAttributeDescription { name = "color-attr", defaultValue = "ffffff" };
            public override IEnumerable<UxmlChildElementDescription> uxmlChildElementsDescription
            {
                get { yield return new UxmlChildElementDescription(typeof(ColorFieldElement)); }
            }

            public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
            {
                base.Init(ve, bag, cc);

                var f = (ColorDropdownField)ve;
                //var choices = ParseChoiceList(m_Choices.GetValueFromBag(bag, cc));
                List<string> choices = new List<string>(){"0d6efd","6610f2","6f42c1","d63384","dc3545","fd7e14","ffc107","198754","20c997","0dcaf0"}; 
                if (choices != null)
                    f.choices = choices;
                f.index = m_Index.GetValueFromBag(bag, cc);
            }
        }



        /// <summary>
        /// Construct a ColorDropdownField.
        /// </summary>
        public ColorDropdownField()
            : this(null) {}

        /// <summary>
        /// Construct a ColorDropdownField.
        /// </summary>
        public ColorDropdownField(string label)
            : base(label) {}

        /// <summary>
        /// Construct a ColorDropdownField.
        /// </summary>
        public ColorDropdownField(List<string> choices, string defaultValue, Func<string, string> formatSelectedValueCallback = null, Func<string, string> formatListItemCallback = null)
            : this(null, choices, defaultValue, formatSelectedValueCallback, formatListItemCallback) {}

        /// <summary>
        /// Construct a ColorDropdownField.
        /// </summary>
        public ColorDropdownField(string label, List<string> choices, string defaultValue, Func<string, string> formatSelectedValueCallback = null, Func<string, string> formatListItemCallback = null)
            : base(label, choices, defaultValue, formatSelectedValueCallback, formatListItemCallback) {}

        /// <summary>
        /// Construct a ColorDropdownField.
        /// </summary>
        public ColorDropdownField(List<string> choices, int defaultIndex, Func<string, string> formatSelectedValueCallback = null, Func<string, string> formatListItemCallback = null)
            : this(null, choices, defaultIndex, formatSelectedValueCallback, formatListItemCallback) {}

        /// <summary>
        /// Construct a ColorDropdownField.
        /// </summary>
        public ColorDropdownField(string label, List<string> choices, int defaultIndex, Func<string, string> formatSelectedValueCallback = null, Func<string, string> formatListItemCallback = null)
            : base(label, choices, defaultIndex, formatSelectedValueCallback, formatListItemCallback) {}
    }
}
