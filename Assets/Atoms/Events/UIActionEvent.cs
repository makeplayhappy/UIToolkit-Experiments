using UnityEngine;

namespace UnityAtoms
{
    /// <summary>
    /// Event of type `UIAction`. Inherits from `AtomEvent&lt;UIAction&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-cherry")]
    [CreateAssetMenu(menuName = "Unity Atoms/Events/UIAction", fileName = "UIActionEvent")]
    public sealed class UIActionEvent : AtomEvent<UIAction>
    {
    }
}
