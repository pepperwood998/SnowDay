using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDectector : MonoBehaviour
{
  [SerializeField] float crashReloadSceneDelay = 1f;
  [SerializeField] ParticleSystem crashParticles;
  [SerializeField] AudioClip crashSFX;

  private AudioSource _audioSource;
  private bool _hasCrashed = false;

  void Start()
  {
    _audioSource = GetComponent<AudioSource>();
  }

  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("Surface") && !_hasCrashed)
    {
      _hasCrashed = true;
      FindObjectOfType<PlayerController>().DisableControls();
      PlayEffect();
      Invoke(nameof(ReloadScene), crashReloadSceneDelay);
    }
  }

  private void ReloadScene()
  {
    SceneManager.LoadScene("Level1");
  }

  private void PlayEffect()
  {
    crashParticles.Play();
    _audioSource.PlayOneShot(crashSFX);
  }
}
