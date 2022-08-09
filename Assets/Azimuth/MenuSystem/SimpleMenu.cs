/// Credit Adam Kapos (Nezz) - http://www.songarc.net
/// Sourced from - https://github.com/YousicianGit/UnityMenuSystem
/// Updated by SimonDarksideJ - Refactored to be a more generic component
using UnityAtoms;
using UnityEngine;

namespace Azimuth
{
    /// <summary>
    /// A base menu class that implements parameterless Show and Hide methods
    /// </summary>
    public abstract class SimpleMenu<T> : Menu<T> where T : SimpleMenu<T>
    {
        public PlayerDataCache playerDataCache;
        [SerializeField]
    //private GameStateVariable GlobalGameState;
        protected UIActionVariable uiAction;
        
        public static void Show()
        {
            Open();
        }

        public static void Hide()
        {
            Close();
        }
    }
}