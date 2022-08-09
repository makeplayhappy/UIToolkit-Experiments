#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityEngine.UIElements;
using UnityAtoms.Editor;

namespace UnityAtoms.Editor
{
    /// <summary>
    /// Event property drawer of type `UIAction`. Inherits from `AtomEventEditor&lt;UIAction, UIActionEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomEditor(typeof(UIActionEvent))]
    public sealed class UIActionEventEditor : AtomEventEditor<UIAction, UIActionEvent> { }
}
#endif
