using UnityEngine;
using UnityEngine.UIElements;

namespace Azimuth
{
    public class HomeMenu : SimpleMenu<HomeMenu> {
        protected override void Awake() {
            base.Awake();

            // Register callbacks to trigger UI Actions (picked up by UIActions)
            documentRoot.Q<Button>(name: "quit").clicked += () => DoUIAction(UIAction.Quit);

            //multiple elements need the query + foreach to assign callback
            documentRoot.Query<Button>(name: "options").ForEach( e => e.clicked += () => DoUIAction(UIAction.GlobalOptions) ); 

            documentRoot.Q<Button>(name: "new-racer").clicked += () => DoUIAction(UIAction.NewRacer);
            documentRoot.Q<Button>(name: "resume").clicked += () => DoUIAction(UIAction.ChooseRacer);

            documentRoot.Q<Button>(name: "achievements").clicked += () => DoUIAction(UIAction.ShowAchievements);
            documentRoot.Q<Button>(name: "coins").clicked += () => DoUIAction(UIAction.Currency);

            //racer-list
            



            
        }

        private void DoUIAction(UIAction action){
            uiAction.Value = action;
        }
    }
}