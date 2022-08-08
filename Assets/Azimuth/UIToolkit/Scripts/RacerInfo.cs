using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
//Azimuth.RacerInfo
namespace Azimuth
{
    public class RacerInfo : VisualElement
    {
        // UxmlFactory and UxmlTraits a
        public new class UxmlFactory : UxmlFactory<RacerInfo, UxmlTraits> {}
        public new class UxmlTraits : VisualElement.UxmlTraits {}

        private RacerItemData itemData;
        private Label labelName;
        private Label labelHoursTrained;
        private Label labelTopSpeed;

        //private Label labelLapsCompleted;
        private Label labelRacesEntered;
        private Label labelRacesCompleted;
        //private Label labelRacesWon;
        private Label labelBestPlacing;
        private Label labelRank;




        public RacerInfo() {
            this.RegisterCallback<GeometryChangedEvent>(OnGeometryChange);
        }

        public void SetRacer(RacerItemData data){
            itemData = data;
            UpdateItems();

        }

        private void UpdateItems(){

            labelName.text = itemData.name;
            labelHoursTrained.text = itemData.hoursTrained.ToString("F1");
            labelTopSpeed.text = itemData.topSpeed.ToString("F1");
            //labelLapsCompleted.text = itemData.hoursTrained.ToString();
            labelRacesEntered.text = itemData.racesEntered.ToString();
            labelRacesCompleted.text = itemData.racesCompleted.ToString();
            //labelRacesWon.text = itemData.hoursTrained.ToString();
            labelBestPlacing.text = itemData.bestPlacing.ToString();
            labelRank.text = itemData.rank.ToString();

        }

        void OnGeometryChange(GeometryChangedEvent evt) {

            labelName = this.Q<Label>(name: "data-name");
            labelHoursTrained = this.Q<Label>(name: "data-hoursTrained");
            labelTopSpeed = this.Q<Label>(name: "data-topSpeed");
            //labelLapsCompleted = this.Q<Label>(name: "data-name");
            labelRacesEntered = this.Q<Label>(name: "data-racesEntered");
            labelRacesCompleted = this.Q<Label>(name: "data-racesCompleted");
            //labelRacesWon = this.Q<Label>(name: "data-name");
            labelBestPlacing = this.Q<Label>(name: "data-bestPlacing");
            labelRank = this.Q<Label>(name: "data-rank");

            Debug.Log("RacerInfo OnGeometryChange");

            if( itemData != null){

                UpdateItems();
            }

            this.UnregisterCallback<GeometryChangedEvent>(OnGeometryChange);
        }


    }
}
