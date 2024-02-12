using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
    public GameObject gameOverObject;
    // Start is called before the first frame update
    void Start()
    {
        gameOverObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.GetIsDead())
        {
            gameOverObject.SetActive(true);
        }
        else
        {
            gameOverObject.SetActive(false);
        }
    }
}
