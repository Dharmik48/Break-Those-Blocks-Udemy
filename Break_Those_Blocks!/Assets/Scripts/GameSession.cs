using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
  // config
  [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
  [SerializeField] int pointsPerBlockDestroyed = 83;
  [SerializeField] TextMeshProUGUI scoreText;
  [SerializeField] SceneLoader sceneLoader;

  // state
  [SerializeField] int currentScore = 0;

  private void Awake()
  {
    int gameStatusObjCount = FindObjectsOfType<GameSession>().Length;

    if (gameStatusObjCount > 1)
    {
      gameObject.SetActive(false);
      Destroy(gameObject);
    }
    else
    {
      DontDestroyOnLoad(gameObject);
    }
  }

  private void Start()
  {
    scoreText.text = currentScore.ToString();
  }

  // Update is called once per frame
  void Update()
  {
    Time.timeScale = gameSpeed;
  }

  public void AddToScore()
  {
    currentScore += pointsPerBlockDestroyed;
    scoreText.text = currentScore.ToString();
  }

  public void ResetGame()
  {
    Destroy(gameObject);
  }
}
