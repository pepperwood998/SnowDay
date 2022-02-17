using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustTrail : MonoBehaviour
{
  [SerializeField] ParticleSystem glidingEffect;

  void OnCollisionEnter2D(Collision2D other)
  {
    if (other.gameObject.CompareTag("Surface"))
    {
      glidingEffect.Play();
    }
  }

  void OnCollisionExit2D(Collision2D other)
  {
    if (other.gameObject.CompareTag("Surface"))
    {
      glidingEffect.Stop();
    }
  }
}
