using UnityEngine;

namespace UnityAtoms
{
    /// <summary>
    /// Event Reference Listener of type `UIAction`. Inherits from `AtomEventReferenceListener&lt;UIAction, UIActionEvent, UIActionEventReference, UIActionUnityEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-orange")]
    [AddComponentMenu("Unity Atoms/Listeners/UIAction Event Reference Listener")]
    public sealed class UIActionEventReferenceListener : AtomEventReferenceListener<
        UIAction,
        UIActionEvent,
        UIActionEventReference,
        UIActionUnityEvent>
    { }
}
