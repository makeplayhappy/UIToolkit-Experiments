using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
//Azimuth.LockableListItem

//Azimuth.LockableListItem
namespace Azimuth
{
    public class LockableListItem : VisualElement
    {
        // UxmlFactory and UxmlTraits a
        public new class UxmlFactory : UxmlFactory<LockableListItem, UxmlTraits> {}
        public new class UxmlTraits : VisualElement.UxmlTraits {}
        //private Label labelRank;




        public LockableListItem() {
            this.RegisterCallback<GeometryChangedEvent>(OnGeometryChange);

            VisualTreeAsset uiAsset = Resources.Load<VisualTreeAsset>("UIElements/Azimuth.LockableListItem");
            //Debug.Log( uiAsset );
            TemplateContainer ui = uiAsset.CloneTree();
            Add(ui);

        }


        void OnGeometryChange(GeometryChangedEvent evt) {
            this.UnregisterCallback<GeometryChangedEvent>(OnGeometryChange);
        }


    }
}
