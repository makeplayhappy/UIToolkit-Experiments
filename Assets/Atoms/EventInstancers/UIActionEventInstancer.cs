using UnityEngine;

namespace UnityAtoms
{
    /// <summary>
    /// Event Instancer of type `UIAction`. Inherits from `AtomEventInstancer&lt;UIAction, UIActionEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-sign-blue")]
    [AddComponentMenu("Unity Atoms/Event Instancers/UIAction Event Instancer")]
    public class UIActionEventInstancer : AtomEventInstancer<UIAction, UIActionEvent> { }
}
