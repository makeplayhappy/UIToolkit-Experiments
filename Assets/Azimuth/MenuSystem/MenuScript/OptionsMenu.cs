using UnityEngine;
using UnityEngine.UIElements;

namespace Azimuth {
    public class OptionsMenu : SimpleMenu<OptionsMenu> {
        protected override void Awake() {
            base.Awake();
           
        }

        public override void OnBackPressed() {
        //PauseMenu.Show();
            Debug.Log("OptionsMenu OnBackPressed");
        }

    }

}

