using UnityEngine;
using UnityEngine.UIElements;

namespace Azimuth {
    public class AchievementsMenu : SimpleMenu<AchievementsMenu> {
        protected override void Awake() {
            base.Awake();
           
        }

        public override void OnBackPressed() {
        //PauseMenu.Show();
            Debug.Log("AchievementsMenu OnBackPressed");
        }

    }

}

