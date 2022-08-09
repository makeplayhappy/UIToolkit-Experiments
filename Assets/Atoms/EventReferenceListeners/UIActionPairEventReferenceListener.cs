using UnityEngine;

namespace UnityAtoms
{
    /// <summary>
    /// Event Reference Listener of type `UIActionPair`. Inherits from `AtomEventReferenceListener&lt;UIActionPair, UIActionPairEvent, UIActionPairEventReference, UIActionPairUnityEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-orange")]
    [AddComponentMenu("Unity Atoms/Listeners/UIActionPair Event Reference Listener")]
    public sealed class UIActionPairEventReferenceListener : AtomEventReferenceListener<
        UIActionPair,
        UIActionPairEvent,
        UIActionPairEventReference,
        UIActionPairUnityEvent>
    { }
}
