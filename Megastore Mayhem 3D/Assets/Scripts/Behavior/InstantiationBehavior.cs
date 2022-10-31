using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class InstantiationBehavior : MonoBehaviour
{
    public GameObject item;
    
    public IntData amountOfObjects;
    void Update()
    {
        var randX = Random.Range(-73, 73);
        var randZ = Random.Range(-73, 73);

        var instanceLoc = new Vector3(randX, 1, randZ);
        
        if (amountOfObjects.intData <= 30)
        {
            Instantiate(item, instanceLoc, Quaternion.identity);
            amountOfObjects.intData++;
        }
    }
}
