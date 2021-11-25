using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
  // config params
  [SerializeField] Paddle paddle1;
  [SerializeField] float pushX = 2f;
  [SerializeField] float pushY = 15f;
  [SerializeField] AudioClip[] ballSounds;

  // state
  Vector2 paddleBallDistance;
  bool hasStarted = false;

  // Cached Component
  AudioSource myAudioSource;

  // Start is called before the first frame update
  void Start()
  {
    paddleBallDistance = transform.position - paddle1.transform.position;
    myAudioSource = GetComponent<AudioSource>();
  }

  // Update is called once per frame
  void Update()
  {
    if (!hasStarted)
    {
      LockBallToPaddle();
      LaunchTheBall();
    }
  }

  private void LaunchTheBall()
  {
    if (Input.GetMouseButtonDown(0))
    {
      GetComponent<Rigidbody2D>().velocity = new Vector2(pushX, pushY);
      hasStarted = true;
    }
  }

  private void LockBallToPaddle()
  {
    Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
    transform.position = paddlePos + paddleBallDistance;
  }

  private void OnCollisionEnter2D(Collision2D other)
  {
    if (hasStarted)
    {
      AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
      myAudioSource.PlayOneShot(clip);
    }
  }
}
