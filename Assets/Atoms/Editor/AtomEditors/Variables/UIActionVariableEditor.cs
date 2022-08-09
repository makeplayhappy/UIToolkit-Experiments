using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.Editor
{
    /// <summary>
    /// Variable Inspector of type `UIAction`. Inherits from `AtomVariableEditor`
    /// </summary>
    [CustomEditor(typeof(UIActionVariable))]
    public sealed class UIActionVariableEditor : AtomVariableEditor<UIAction, UIActionPair> { }
}
