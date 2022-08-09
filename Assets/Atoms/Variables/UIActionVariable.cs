using UnityEngine;
using System;

namespace UnityAtoms
{
    /// <summary>
    /// Variable of type `UIAction`. Inherits from `AtomVariable&lt;UIAction, UIActionPair, UIActionEvent, UIActionPairEvent, UIActionUIActionFunction&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-lush")]
    [CreateAssetMenu(menuName = "Unity Atoms/Variables/UIAction", fileName = "UIActionVariable")]
    public sealed class UIActionVariable : AtomVariable<UIAction, UIActionPair, UIActionEvent, UIActionPairEvent, UIActionUIActionFunction>
    {
        protected override bool ValueEquals(UIAction other)
        {
            //throw new NotImplementedException();
            return (this.Value == null && other == null) || this.Value != null && other != null && this.Value == other;
        }
    }
}
