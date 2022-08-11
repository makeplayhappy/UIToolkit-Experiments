using UnityEngine;
using UnityEngine.UIElements;

namespace Azimuth {
    public class TrackWorldGeneratorMenu : SimpleMenu<TrackWorldGeneratorMenu> {

        private Label labelSeed;
        private Label labelIdentity;
        protected override void Awake() {
            base.Awake();
            labelSeed = documentRoot.Q<Label>(name: "label-seed");
            labelIdentity = documentRoot.Q<Label>(name: "label-identity");
            documentRoot.Q<Button>(name: "shuffle").clicked += () => Shuffle();

            //documentRoot.Query(name: "seed").Children<Button>(name: "prev").Build().clicked += () => SeedUpdate(false);
            //documentRoot.Query(name: "seed").Children<Button>(name: "next").Build().clicked += () => SeedUpdate(true);
            documentRoot.Q(name: "seed").Q<Button>(name: "prev").clicked += () => SeedUpdate(false);
            documentRoot.Q(name: "seed").Q<Button>(name: "next").clicked += () => SeedUpdate(true);
    
            //documentRoot.Q<Button>(name: "shuffle").clicked += () => Shuffle();
            //documentRoot.Q<Button>(name: "shuffle").clicked += () => Shuffle();

           
        }

        public void GenerateTrack(){
            Debug.Log("TrackWorldGeneratorMenu GenerateTrack");
        }

        public void SeedUpdate(bool isNext = true){
            if(isNext){
                Debug.Log("TrackWorldGeneratorMenu update seed next");
            }else{
                //go back...
                Debug.Log("TrackWorldGeneratorMenu update seed prev");

            }
            
        }

        public void IdentifyUpdate(bool isNext = true){
            if(isNext){
                Debug.Log("TrackWorldGeneratorMenu update identity next");
            }else{
                //go back...
                Debug.Log("TrackWorldGeneratorMenu update identity prev");

            }
        }

        public void Shuffle(){
            
            Debug.Log("TrackWorldGeneratorMenu Shuffle");

        }



        public override void OnBackPressed() {
        //PauseMenu.Show();
            Debug.Log("TrackWorldGeneratorMenu OnBackPressed");
        }

    }

}

