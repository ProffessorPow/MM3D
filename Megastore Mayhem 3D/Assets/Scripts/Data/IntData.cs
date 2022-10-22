using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class IntData : ScriptableObject
{
    public int intData;
    
    public void UpdateValue(int num)
    {
        intData += num;
    }

    public void UpdateValue(IntData obj)
    {
        intData = obj.intData;
    }

    public void SetValue(int num)
    {
        intData = num;
    }
}
