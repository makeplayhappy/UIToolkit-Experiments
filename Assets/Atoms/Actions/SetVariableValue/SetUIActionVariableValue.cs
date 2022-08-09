using UnityEngine;
using UnityAtoms.BaseAtoms;

namespace UnityAtoms
{
    /// <summary>
    /// Set variable value Action of type `UIAction`. Inherits from `SetVariableValue&lt;UIAction, UIActionPair, UIActionVariable, UIActionConstant, UIActionReference, UIActionEvent, UIActionPairEvent, UIActionVariableInstancer&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-purple")]
    [CreateAssetMenu(menuName = "Unity Atoms/Actions/Set Variable Value/UIAction", fileName = "SetUIActionVariableValue")]
    public sealed class SetUIActionVariableValue : SetVariableValue<
        UIAction,
        UIActionPair,
        UIActionVariable,
        UIActionConstant,
        UIActionReference,
        UIActionEvent,
        UIActionPairEvent,
        UIActionUIActionFunction,
        UIActionVariableInstancer>
    { }
}
