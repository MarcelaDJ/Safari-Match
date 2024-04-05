using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStartScreen : MonoBehaviour
{
    // Start is called before the first frame update
  public void StartBtnClicked()
    {
        GameManager.Instance.StartGame();
    }
}
