using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Fades : MonoBehaviour
{

    private SpriteRenderer _rend;

    // Start is called before the first frame update
    void Start()
    {
        _rend = GetComponent<SpriteRenderer>();
        StartCoroutine(FadeOut());
        
    }

    IEnumerator FadeOut()
    {
        Color color = _rend.color;
        for(float alpha = 1.0f; alpha >=0.0f; alpha -= 0.01f)
        {
            color.a = alpha;
            _rend.color = color;
            yield return new WaitForSeconds(0.02f); // para devolverle el control a unity duarante ese tiempo
        }
        StartCoroutine(FadeIn()); // para invocarlo cuando acabe el fade out 
    }
    IEnumerator FadeIn()
    {
        Color color = _rend.color;
        for (float alpha = 0.0f; alpha <= 1.0f; alpha += 0.01f)
        {
            color.a = alpha;
            _rend.color = color;
            yield return new WaitForSeconds(0.02f); // para devolverle el control a unity duarante ese tiempo
        }
        StartCoroutine(FadeOut());
    }
   
}
