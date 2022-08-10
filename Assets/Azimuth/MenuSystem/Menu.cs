/// Credit Adam Kapos (Nezz) - http://www.songarc.net
/// Sourced from - https://github.com/YousicianGit/UnityMenuSystem
/// Updated by SimonDarksideJ - Refactored to be a more generic component
using UnityEngine;
using UnityEngine.UIElements;

namespace Azimuth
{
    public abstract class Menu<T> : Menu where T : Menu<T>
    {
        protected VisualElement documentRoot;
        
        public static T Instance { get; private set; }


        protected virtual void Awake()
        {
            Instance = (T)this;
            documentRoot = document.rootVisualElement;
        }

        protected virtual void OnDestroy()
        {
            Instance = null;
        }

        protected static void Open()
        {
            GameObject clonedGameObject = null;
            if (Instance == null)
            {
                MenuManager.Instance.CreateInstance(typeof(T).Name, out clonedGameObject);
                MenuManager.Instance.OpenMenu(clonedGameObject.GetMenu());
            }
            else
            {
                //Instance.gameObject.SetActive(true);
                Instance.SetActive(true);
                MenuManager.Instance.OpenMenu(Instance);
            }
        }

        public override void SetActive(bool value) 
        {
            Instance.documentRoot.style.display = value ? DisplayStyle.Flex : DisplayStyle.None;
        }

        protected static void Close()
        {
            if (Instance == null)
            {
                Debug.LogErrorFormat("Trying to close menu {0} but Instance is null", typeof(T));
                return;
            }

            MenuManager.Instance.CloseMenu(Instance);
        }

        public override void OnBackPressed()
        {
            Close();
        }
    }

    public abstract class Menu : MonoBehaviour
    {
        [Tooltip("Destroy the Game Object when menu is closed (reduces memory usage)")]
        public bool DestroyWhenClosed = true;

        [Tooltip("Disable menus that are under this one in the stack")]
        public bool DisableMenusUnderneath = true;

        public UIDocument document;

        public abstract void OnBackPressed();
        public abstract void SetActive(bool value);
    }
}
