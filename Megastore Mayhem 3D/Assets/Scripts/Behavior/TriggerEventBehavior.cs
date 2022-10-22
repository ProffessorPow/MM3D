using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEventBehavior : MonoBehaviour
{
    public UnityEvent triggerEnterEvent, exitTriggerEvent;

    private void OnTriggerEnter(Collider other)
    {
        triggerEnterEvent.Invoke();
    }

    private void OnCollisionExit(Collision other)
    {
        exitTriggerEvent.Invoke();
    }

    private void OnParticleCollision(GameObject other)
    {
        triggerEnterEvent.Invoke();
    }
}
