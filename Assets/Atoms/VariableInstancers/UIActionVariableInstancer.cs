using UnityEngine;
using UnityAtoms.BaseAtoms;

namespace UnityAtoms
{
    /// <summary>
    /// Variable Instancer of type `UIAction`. Inherits from `AtomVariableInstancer&lt;UIActionVariable, UIActionPair, UIAction, UIActionEvent, UIActionPairEvent, UIActionUIActionFunction&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-hotpink")]
    [AddComponentMenu("Unity Atoms/Variable Instancers/UIAction Variable Instancer")]
    public class UIActionVariableInstancer : AtomVariableInstancer<
        UIActionVariable,
        UIActionPair,
        UIAction,
        UIActionEvent,
        UIActionPairEvent,
        UIActionUIActionFunction>
    { }
}
