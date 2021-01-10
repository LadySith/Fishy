using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkleFish : MonoBehaviour
{
    [SerializeField] ParticleSystem sparkleParticle = null;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "player")
        {
            Debug.Log("Player collided with " + collision.gameObject.name);
            Sparkle();
        }
    }

    void Sparkle()
    {
        sparkleParticle.Play();
    }
}
