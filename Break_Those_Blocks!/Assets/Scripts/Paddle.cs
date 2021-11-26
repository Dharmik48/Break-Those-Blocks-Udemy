using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
  // config params
  [SerializeField] float screenWidthInUnits = 16f;
  [SerializeField] float minPaddlePosX = 1f;
  [SerializeField] float maxPaddlePosX = 15f;

  // cached references
  [SerializeField] GameSession gameStatus;
  [SerializeField] Ball theBall;

  // Start is called before the first frame update
  void Start()
  {
    gameStatus = FindObjectOfType<GameSession>();
    theBall = FindObjectOfType<Ball>();
  }

  // Update is called once per frame
  void Update()
  {
    // float mousePosInUnitsX = Input.mousePosition.x / Screen.width * screenWidthInUnits;

    Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
    paddlePos.x = Mathf.Clamp(GetXPos(), minPaddlePosX, maxPaddlePosX);
    transform.position = paddlePos;

  }

  private float GetXPos()
  {
    if (gameStatus.IsAutoPlayEnabled())
    {
      return theBall.transform.position.x;
    }
    else
    {
      return Input.mousePosition.x / Screen.width * screenWidthInUnits;
    }
  }
}
