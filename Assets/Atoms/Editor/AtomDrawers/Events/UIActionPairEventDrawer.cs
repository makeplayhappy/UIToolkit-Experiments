#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.Editor
{
    /// <summary>
    /// Event property drawer of type `UIActionPair`. Inherits from `AtomDrawer&lt;UIActionPairEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(UIActionPairEvent))]
    public class UIActionPairEventDrawer : AtomDrawer<UIActionPairEvent> { }
}
#endif
