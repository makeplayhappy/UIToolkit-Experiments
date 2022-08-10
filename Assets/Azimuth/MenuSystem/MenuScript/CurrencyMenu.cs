using UnityEngine;
using UnityEngine.UIElements;

namespace Azimuth {
    public class CurrencyMenu : SimpleMenu<CurrencyMenu> {
        protected override void Awake() {
            base.Awake();
           
        }

        public override void OnBackPressed() {
        //PauseMenu.Show();
            Debug.Log("CurrencyMenu OnBackPressed");
        }

    }

}

