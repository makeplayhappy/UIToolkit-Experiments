using System;
using UnityEngine;
namespace UnityAtoms
{
    /// <summary>
    /// IPair of type `&lt;UIAction&gt;`. Inherits from `IPair&lt;UIAction&gt;`.
    /// </summary>
    [Serializable]
    public struct UIActionPair : IPair<UIAction>
    {
        public UIAction Item1 { get => _item1; set => _item1 = value; }
        public UIAction Item2 { get => _item2; set => _item2 = value; }

        [SerializeField]
        private UIAction _item1;
        [SerializeField]
        private UIAction _item2;

        public void Deconstruct(out UIAction item1, out UIAction item2) { item1 = Item1; item2 = Item2; }
    }
}