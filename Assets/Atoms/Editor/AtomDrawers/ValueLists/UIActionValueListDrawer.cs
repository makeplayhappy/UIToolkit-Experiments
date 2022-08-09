#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.Editor
{
    /// <summary>
    /// Value List property drawer of type `UIAction`. Inherits from `AtomDrawer&lt;UIActionValueList&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(UIActionValueList))]
    public class UIActionValueListDrawer : AtomDrawer<UIActionValueList> { }
}
#endif
