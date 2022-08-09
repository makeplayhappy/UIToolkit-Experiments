using System;

namespace UnityAtoms
{
    /// <summary>
    /// Event Reference of type `UIAction`. Inherits from `AtomEventReference&lt;UIAction, UIActionVariable, UIActionEvent, UIActionVariableInstancer, UIActionEventInstancer&gt;`.
    /// </summary>
    [Serializable]
    public sealed class UIActionEventReference : AtomEventReference<
        UIAction,
        UIActionVariable,
        UIActionEvent,
        UIActionVariableInstancer,
        UIActionEventInstancer>, IGetEvent 
    { }
}
