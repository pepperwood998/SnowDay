using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  [SerializeField] float torqueAmount = 6.0f;
  [SerializeField] float boostSpeed = 30.0f;
  [SerializeField] float baseSpeed = 20.0f;

  private Rigidbody2D _rb2d;
  private SurfaceEffector2D _surfaceEffector2D;
  private bool _canMove = true;

  void Start()
  {
    _rb2d = GetComponent<Rigidbody2D>();
    _surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();

  }

  void Update()
  {
    if (!_canMove)
    {
      return;
    }

    RotatePlayer();
    RespondToBoost();
  }

  public void DisableControls()
  {
    _canMove = false;
  }

  private void RespondToBoost()
  {
    if (Input.GetKey(KeyCode.UpArrow))
    {
      _surfaceEffector2D.speed = boostSpeed;
    }
    else
    {
      _surfaceEffector2D.speed = baseSpeed;
    }
  }

  private void RotatePlayer()
  {
    if (Input.GetKey(KeyCode.LeftArrow))
    {
      _rb2d.AddTorque(torqueAmount);
    }
    else if (Input.GetKey(KeyCode.RightArrow))
    {
      _rb2d.AddTorque(-torqueAmount);
    }
  }
}
