using UnityEngine;
using UnityEngine.UIElements;

namespace Azimuth {
    public class TrackWorldRewardsMenu : SimpleMenu<TrackWorldRewardsMenu> {
        protected override void Awake() {
            base.Awake();
           
        }

        public override void OnBackPressed() {
        //PauseMenu.Show();
            Debug.Log("TrackWorldRewardsMenu OnBackPressed");
        }

    }

}

