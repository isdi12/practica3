using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFunctions : MonoBehaviour
{
    // Start is called before the first frame update
   public void ExitGame()
    {
        GameManager.instance.ExitGame();
    }

    public void LoadScene(string sceneName)
    {
        GameManager.instance.LoadScene(sceneName);
    }
}
