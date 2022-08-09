#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.Editor
{
    /// <summary>
    /// Constant property drawer of type `UIAction`. Inherits from `AtomDrawer&lt;UIActionConstant&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(UIActionConstant))]
    public class UIActionConstantDrawer : VariableDrawer<UIActionConstant> { }
}
#endif
