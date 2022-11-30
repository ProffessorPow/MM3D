using UnityEngine;

public class ParticleBehavior : MonoBehaviour
{
    void Start()
    {
        gameObject.GetComponent<ParticleSystem>().Stop();
    }

}
