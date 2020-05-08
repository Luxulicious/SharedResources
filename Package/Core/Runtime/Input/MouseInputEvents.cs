using System;
using UnityEngine;
using UnityEngine.Events;

namespace TheLuxGames.SharedResources.Input
{
    [Serializable]
    public class MousePositionUpdateEvent : UnityEvent<Vector2> { }
    [Serializable]
    public class ContinuousMousePositionEvent : UnityEvent<Vector2> { }
    /// <summary>
    /// Should fire when there is a left click.
    /// </summary>
    [Serializable]
    public class MouseButtonPrimaryEvent : UnityEvent<float> { }
    /// <summary>
    /// Should fire when there is a right click.
    /// </summary>
    [Serializable]
    public class MouseButtonSecondaryClickEvent : UnityEvent<float> { }
    /// <summary>
    /// Should fire when there is a middle click
    /// </summary>
    [Serializable]
    public class MouseButtonTertiaryEvent : UnityEvent<float> { }

    [Serializable]
    public class MouseButtonPrimaryUpEvent : UnityEvent<float> { }
    [Serializable]
    public class MouseButtonSecondaryUpEvent : UnityEvent<float> { }
    [Serializable]
    public class MouseButtonTertiaryUpEvent : UnityEvent<float> { }

    [Serializable]
    public class MouseButtonPrimaryDownEvent : UnityEvent { }
    [Serializable]
    public class MouseButtonSecondaryDownEvent : UnityEvent { }
    [Serializable]
    public class MouseButtonTertiaryDownEvent : UnityEvent { }
}
