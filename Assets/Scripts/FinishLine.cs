using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
  [SerializeField] float finishReloadSceneDelay = 1.0f;
  [SerializeField] ParticleSystem finishParticles;

  private AudioSource _finishAudio;

  void Start()
  {
    _finishAudio = GetComponent<AudioSource>();
  }
  void OnTriggerEnter2D(Collider2D other)

  {
    if (other.CompareTag("Player"))
    {
      finishParticles.Play();
      _finishAudio.Play();
      Invoke(nameof(ReloadScene), finishReloadSceneDelay);
    }
  }

  private void ReloadScene()
  {
    SceneManager.LoadScene("Level1");
  }
}
