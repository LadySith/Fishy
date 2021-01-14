using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkleFish : MonoBehaviour
{
    public ParticleSystem sparkleParticle;

    void Awake()
    {
        sparkleParticle = GetComponent<ParticleSystem>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "player")
        {
            Debug.Log("Player collided with " + this.gameObject.name);
            Sparkle();
        }
    }

    void Sparkle()
    {
        sparkleParticle.Play();
    }
}
