using UnityEngine;

namespace UnityAtoms
{
    /// <summary>
    /// Event of type `UIActionPair`. Inherits from `AtomEvent&lt;UIActionPair&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-cherry")]
    [CreateAssetMenu(menuName = "Unity Atoms/Events/UIActionPair", fileName = "UIActionPairEvent")]
    public sealed class UIActionPairEvent : AtomEvent<UIActionPair>
    {
    }
}
