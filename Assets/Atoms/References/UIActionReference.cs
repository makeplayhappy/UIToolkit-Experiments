using System;
using UnityAtoms.BaseAtoms;

namespace UnityAtoms
{
    /// <summary>
    /// Reference of type `UIAction`. Inherits from `AtomReference&lt;UIAction, UIActionPair, UIActionConstant, UIActionVariable, UIActionEvent, UIActionPairEvent, UIActionUIActionFunction, UIActionVariableInstancer, AtomCollection, AtomList&gt;`.
    /// </summary>
    [Serializable]
    public sealed class UIActionReference : AtomReference<
        UIAction,
        UIActionPair,
        UIActionConstant,
        UIActionVariable,
        UIActionEvent,
        UIActionPairEvent,
        UIActionUIActionFunction,
        UIActionVariableInstancer>, IEquatable<UIActionReference>
    {
        public UIActionReference() : base() { }
        public UIActionReference(UIAction value) : base(value) { }
        public bool Equals(UIActionReference other) { return base.Equals(other); }
        protected override bool ValueEquals(UIAction other)
        {
            throw new NotImplementedException();
        }
    }
}
