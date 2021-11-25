using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
  // params
  [SerializeField] int remainingBlocks;

  // cached reference;
  SceneLoader sceneLoader;

  private void Start()
  {
    sceneLoader = FindObjectOfType<SceneLoader>();
  }

  public void CountBlocks()
  {
    remainingBlocks++;
  }

  public void BlockDestroyed()
  {
    remainingBlocks--;
    if (remainingBlocks <= 0)
    {
      sceneLoader.LoadNextScene();
    }
  }
}
