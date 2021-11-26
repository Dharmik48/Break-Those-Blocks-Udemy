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
  [SerializeField] float randomFactor = 0.5f;

  // state
  Vector2 paddleBallDistance;
  bool hasStarted = false;

  // Cached Component
  AudioSource myAudioSource;
  Rigidbody2D myRigidbody2D;

  // Start is called before the first frame update
  void Start()
  {
    paddleBallDistance = transform.position - paddle1.transform.position;
    myAudioSource = GetComponent<AudioSource>();
    myRigidbody2D = GetComponent<Rigidbody2D>();
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
      myRigidbody2D.velocity = new Vector2(pushX, pushY);
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
    Vector2 velocityTweak = new Vector2(UnityEngine.Random.Range(0, randomFactor), UnityEngine.Random.Range(0, randomFactor));
    if (hasStarted)
    {
      AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
      myAudioSource.PlayOneShot(clip);
      myRigidbody2D.velocity += velocityTweak;
    }
  }
}
