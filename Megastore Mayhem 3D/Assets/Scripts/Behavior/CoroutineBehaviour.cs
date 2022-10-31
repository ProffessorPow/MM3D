using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class CoroutineBehaviour : MonoBehaviour
{
    public UnityEvent startEvent, startCountEvent, repeatCountEvent, endCountEvent, repeatUntilFalse;
    

    public IntData counterNum;
    
    public float seconds = 3.0f;
    private WaitForSeconds wfsObj;
    private WaitForFixedUpdate wffuObj;
    public bool CanRun { get; set; }
    public void Start()
    {
        wfsObj = new WaitForSeconds((seconds));
        wffuObj = new WaitForFixedUpdate();
        startEvent.Invoke();
    }
    
    public void StartCounting()
    {
        StartCoroutine(Counting());
    }
    
    private IEnumerator Counting()
    {
        startCountEvent.Invoke();

        while (counterNum.intData > 0)
        {
            repeatCountEvent.Invoke();
            counterNum.intData--;
            Debug.Log(seconds);
            yield return wfsObj;
        }
        endCountEvent.Invoke();
    }

    public void StartRepeatUntilFalse()
    {
        CanRun = true;
        StartCoroutine(RepeatUntilFalse());
    }

    private IEnumerator RepeatUntilFalse()
    {
        while (CanRun)
        {
            yield return wfsObj;
            repeatUntilFalse.Invoke();
        }
    }

}
