using System.Collections;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.Events;

public class MatchBehavior : MonoBehaviour
{
    public ID idObj;
    public UnityEvent matchEvent, noMatchEvent, noMatchDelayed;

    private IEnumerator OnTriggerEnter(Collider other)
    {
        var tempObj = other.GetComponent<IDContainerBehavior>();
        if (tempObj == null)
            yield break;

        var otherID = tempObj.idObj;
        if (otherID == idObj)
        {
            Debug.Log("Matched");
            matchEvent.Invoke();
        }
        else
        {
            noMatchEvent.Invoke();
            Debug.Log("No Match");
            yield return new WaitForSeconds(0.5f);
        }
    }
}
