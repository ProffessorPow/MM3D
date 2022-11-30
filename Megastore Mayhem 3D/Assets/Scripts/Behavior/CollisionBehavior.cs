using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class CollisionBehavior : MonoBehaviour
{
    public UnityEvent onTrigger;

    private void OnTriggerEnter(Collider other)
    {
        onTrigger.Invoke();
        gameObject.SetActive(false);
    }
}
