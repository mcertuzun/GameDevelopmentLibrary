using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationEventTrigger : MonoBehaviour, ITrigger
{
    [SerializeField] UnityEvent Event;

    public UnityEvent _TriggerEvent => Event;

    public void TriggerEvent()
    {
        Event?.Invoke();
    }
}
