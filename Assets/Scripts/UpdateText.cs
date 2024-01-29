using System.Collections;
using System.Collections.Generic;
using TMPro; // avisa al codigo de que vamos a usar el tmpro 
using UnityEditor;
using UnityEngine;

public class UpdateText : MonoBehaviour
{
    public GameManager.GameManagerVariables variable;

    private TMP_Text scoreComponent;

    private void Start()
    {
        scoreComponent = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (variable) // el switch es como usar el if else se pueden ambas 
        {
            case GameManager.GameManagerVariables.TIME: 
                scoreComponent.text = "Time:" + GameManager.instance.GetTime().ToString("#.##"); // esto sirve para actualizar el tiempo
                break;

            case GameManager.GameManagerVariables.POINTS: 
                scoreComponent.text = "Score:" + GameManager.instance.GetPoints();
                break;
            default:
                break;
        }
    }
}
