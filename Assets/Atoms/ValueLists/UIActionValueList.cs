using UnityEngine;

namespace UnityAtoms
{
    /// <summary>
    /// Value List of type `UIAction`. Inherits from `AtomValueList&lt;UIAction, UIActionEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-piglet")]
    [CreateAssetMenu(menuName = "Unity Atoms/Value Lists/UIAction", fileName = "UIActionValueList")]
    public sealed class UIActionValueList : AtomValueList<UIAction, UIActionEvent> { }
}
