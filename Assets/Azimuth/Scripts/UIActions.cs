using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityAtoms;
using UnityAtoms.BaseAtoms;


namespace Azimuth{
// This is used to send events around the syetm from the UI

    public class UIActions : MonoBehaviour {

        public UIAction transientAction;
        public UIAction actionTaken;
        public UIAction previousActionTaken;

        [SerializeField]
        //private GameStateVariable GlobalGameState;
        private UIActionVariable uiAction;

        [SerializeField]   
        private UIActionPairEvent uiActionPairEvent;

        public void Actioned(){
            previousActionTaken = actionTaken;
            actionTaken = transientAction;
        }

        //Using UIActionPair so we get this and the last action (for confirm button)
        private void UIActionChange(UIActionPair newPairState){

            
            //Debug.Log("UIActions Changed: " + newPairState);
            //Debug.Log("UIActions Changed: " + newPairState.Item1);
            //Debug.Log("UIActions Changed: " + newPairState.Item2);

            
            transientAction = newPairState.Item1;
            if( transientAction == UIAction.Confirm ){
                transientAction = newPairState.Item2;
            }


            switch(transientAction){
                case UIAction.Quit:
                    //Debug.Log("UIActions Quit");

                break;
                case UIAction.Back:
                    //Debug.Log("UIActions Back");
                    //get this menus sort order
                    MenuManager.Instance.ShowPreviousMenu(); // GetPreviousMenu()
                    //lastMenu.Show();


                break;

                case UIAction.RacerMenu:
                    //Debug.Log("UIActions RacerMenu");
                    CarMenu.Show();
                break;

                case UIAction.MainMenu:
                    //Debug.Log("UIActions MainMenu");
                    HomeMenu.Show();
                    //ExShopMenu.Show();

                break;

                case UIAction.ShowAchievements:
                    //Debug.Log("UIActions MainMenu");
                    AchievementsMenu.Show();
                    //ExShopMenu.Show();

                break;

                case UIAction.Currency:
                    //Debug.Log("UIActions MainMenu");
                    CurrencyMenu.Show();
                    //ExShopMenu.Show();

                break;

                

                

                case UIAction.OptionsMenu:
                    Debug.Log("OptionsMenu Show" + transientAction);
                    OptionsMenu.Show();
                break;
                default:
                   // Debug.Log("Unknown " + transientAction);
                break;

        
            }
        }

        void Awake(){
            uiActionPairEvent.Register(this.UIActionChange);        
        }

        void OnDestroy(){
            uiActionPairEvent.Unregister(this.UIActionChange);
        }

    }
}