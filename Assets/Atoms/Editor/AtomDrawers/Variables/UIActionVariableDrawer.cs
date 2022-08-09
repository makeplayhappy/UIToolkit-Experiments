#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.Editor
{
    /// <summary>
    /// Variable property drawer of type `UIAction`. Inherits from `AtomDrawer&lt;UIActionVariable&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(UIActionVariable))]
    public class UIActionVariableDrawer : VariableDrawer<UIActionVariable> { }
}
#endif
