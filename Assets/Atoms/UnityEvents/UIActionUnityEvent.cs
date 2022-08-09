using System;
using UnityEngine.Events;

namespace UnityAtoms
{
    /// <summary>
    /// None generic Unity Event of type `UIAction`. Inherits from `UnityEvent&lt;UIAction&gt;`.
    /// </summary>
    [Serializable]
    public sealed class UIActionUnityEvent : UnityEvent<UIAction> { }
}
