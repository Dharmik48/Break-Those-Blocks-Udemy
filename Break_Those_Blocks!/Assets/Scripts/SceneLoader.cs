using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
  public void LoadNextScene()
  {
    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    if (currentSceneIndex == SceneManager.sceneCountInBuildSettings - 1)
    {
      LoadStartScreen();
    }
    else
    {
      SceneManager.LoadScene(currentSceneIndex + 1);

    }
  }

  public void LoadStartScreen()
  {
    SceneManager.LoadScene(0);
  }

  public void QuitGame()
  {
    Application.Quit();
  }
}
