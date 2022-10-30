
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public Transform playerT;
    private Transform cameraT;

    private Vector3 offset = new Vector3(0, 8, -26);

    void Start()
    {
        cameraT = gameObject.GetComponent<Transform>();
    }

    void Update()
    {
        cameraT.position = playerT.position + offset;
    }
}
