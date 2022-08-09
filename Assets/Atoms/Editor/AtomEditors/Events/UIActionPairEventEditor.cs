#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityEngine.UIElements;
using UnityAtoms.Editor;

namespace UnityAtoms.Editor
{
    /// <summary>
    /// Event property drawer of type `UIActionPair`. Inherits from `AtomEventEditor&lt;UIActionPair, UIActionPairEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomEditor(typeof(UIActionPairEvent))]
    public sealed class UIActionPairEventEditor : AtomEventEditor<UIActionPair, UIActionPairEvent> { }
}
#endif
