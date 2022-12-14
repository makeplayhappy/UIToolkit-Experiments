/// Credit Adam Kapos (Nezz) - http://www.songarc.net
/// Sourced from - https://github.com/YousicianGit/UnityMenuSystem
/// Updated by SimonDarksideJ - Refactored to be a more generic component
/// Updated by SionDarksideJ - Fixed implementation as it assumed GO's we automatically assigned to instances
using UnityEngine;
using UnityEngine.UIElements;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace Azimuth
{
    [AddComponentMenu("UI/Extensions/Menu Manager")]
    [DisallowMultipleComponent]
    public class MenuManager : MonoBehaviour
    {
        [SerializeField]
        private Menu[] menuScreens;

        public Menu[] MenuScreens
        {
            get { return menuScreens; }
            set { menuScreens = value; }
        }

        [SerializeField]
        private int startScreen = 0;

        public int StartScreen
        {
            get { return startScreen; }
            set { startScreen = value; }
        }

        private Stack<Menu> menuStack = new Stack<Menu>();

        public static MenuManager Instance { get; set; }

        private void Start()
        {
            Instance = this;
            if (MenuScreens.Length > 0 + StartScreen)
            {
                var startMenu = CreateInstance(MenuScreens[StartScreen].name);
                OpenMenu(startMenu.GetMenu());
            }
            else
            {
                Debug.LogError("Not enough Menu Screens configured");
            }
        }

        private void OnDestroy()
        {
            Instance = null;
        }

        public GameObject CreateInstance(string MenuName)
        {
            var prefab = GetPrefab(MenuName);

            return Instantiate(prefab, transform);
        }

        public void CreateInstance(string MenuName, out GameObject menuInstance)
        {
            var prefab = GetPrefab(MenuName);

            menuInstance = Instantiate(prefab, transform);
        }

        // alternative definition version
        //public void CreateInstance<T>() where T : Menu {
        //    var prefab = GetPrefab<T>();
        //    Instantiate(prefab, transform);
        //}

        public void OpenMenu(Menu menuInstance)
        {
            // De-activate top menu
            if (menuStack.Count > 0)
            {
                if (menuInstance.DisableMenusUnderneath)
                {
                    foreach (var menu in menuStack)
                    {
                        menu.SetActive(false);

                        if (menu.DisableMenusUnderneath)
                            break;
                    }
                }

                var topDocument = menuInstance.document;
                var previousDocument = menuStack.Peek().document;
                topDocument.sortingOrder = previousDocument.sortingOrder + 1;

                //Canvas topCanvas = menuInstance.GetComponent<Canvas>();
                //if (topCanvas != null)
                //{
                //    Canvas previousCanvas = menuStack.Peek().GetComponent<Canvas>();
                //    if(previousCanvas != null)
                //    {
                //        topCanvas.sortingOrder = previousCanvas.sortingOrder + 1;
                //    }
                //}

            }

            menuStack.Push(menuInstance);
        }

        // there is probably a better way to do this --- I can't think of one, we do have to run through the sortOrders 
        // possibly triggering Show on the menu might be more consisitent
        public void ShowPreviousMenu(){
            //get current sort order

            var currentMenu = menuStack.Peek();
            var currentDocument  = currentMenu.document;
            float currentSortingOrder = currentDocument.sortingOrder;

            float previousSortOrder = -1f;
            Menu prevMenu = currentMenu;

            foreach (var menu in menuStack){
                if( menu.document.sortingOrder < currentSortingOrder && menu.document.sortingOrder > previousSortOrder){
                    previousSortOrder = menu.document.sortingOrder;
                    prevMenu = menu;
                }
                
            }


            if( previousSortOrder > -1){
                menuStack.Peek().SetActive(false);
                prevMenu.document.sortingOrder = currentSortingOrder + 1;
                prevMenu.SetActive(true);
                menuStack.Push(prevMenu);
/*
                foreach (var menu in menuStack){
                    if( menu.document.sortingOrder == previousSortOrder){
                        menuStack.Push(menu);
                    }
                }
*/


                /*
                currentDocument.SetActive(false);
                var prevMenu = menuStack[]
                menuStack.Push(menuInstance);

                return defaultMenu;*/
            }

        }

        private GameObject GetPrefab(string PrefabName)
        {
            for (int i = 0; i < MenuScreens.Length; i++)
            {
                if (MenuScreens[i].name == PrefabName)
                {
                    return MenuScreens[i].gameObject;
                }
            }
            throw new MissingReferenceException("Prefab not found for " + PrefabName);
        }

        // alternative prefab definitions
        //private T GetPrefab<T>() where T : Menu {
        //    // Get prefab dynamically, based on public fields set from Unity
        //    // You can use private fields with SerializeField attribute too
        //    var fields = this.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
        //    foreach (var field in fields) {
        //        var prefab = field.GetValue(this) as T;
        //        if (prefab != null) {
        //            return prefab;
        //        }
        //    }
        //
        //    throw new MissingReferenceException("Prefab not found for type " + typeof(T));
        //}

        public void CloseMenu(Menu menu)
        {
            if (menuStack.Count == 0)
            {
                Debug.LogErrorFormat(menu, "{0} cannot be closed because menu stack is empty", menu.GetType());
                return;
            }

            if (menuStack.Peek() != menu)
            {
                Debug.LogErrorFormat(menu, "{0} cannot be closed because it is not on top of stack", menu.GetType());
                return;
            }

            CloseTopMenu();
        }

        public void CloseTopMenu()
        {
            var menuInstance = menuStack.Pop();

            if (menuInstance.DestroyWhenClosed)
                Destroy(menuInstance.gameObject);
            else
                menuInstance.SetActive(false);

            // Re-activate top menu
            // If a re-activated menu is an overlay we need to activate the menu under it
            foreach (var menu in menuStack)
            {
                menu.SetActive(true);

                if (menu.DisableMenusUnderneath)
                    break;
            }
        }


        
#if UNITY_IOS

#else
        private void Update()
        {
            // On Android the back button is sent as Esc
            if (Input.GetKeyDown(KeyCode.Escape) && menuStack.Count > 0)
            {
                menuStack.Peek().OnBackPressed();
            }
        }
#endif

    }

    public static class MenuExtensions
    {
        public static Menu GetMenu(this GameObject go)
        {
            return go.GetComponent<Menu>();
        }
    }

}