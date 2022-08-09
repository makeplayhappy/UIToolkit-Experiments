using System;

namespace UnityAtoms
{
    /// <summary>
    /// Event Reference of type `UIActionPair`. Inherits from `AtomEventReference&lt;UIActionPair, UIActionVariable, UIActionPairEvent, UIActionVariableInstancer, UIActionPairEventInstancer&gt;`.
    /// </summary>
    [Serializable]
    public sealed class UIActionPairEventReference : AtomEventReference<
        UIActionPair,
        UIActionVariable,
        UIActionPairEvent,
        UIActionVariableInstancer,
        UIActionPairEventInstancer>, IGetEvent 
    { }
}
