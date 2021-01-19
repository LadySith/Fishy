using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTween : MonoBehaviour
{
    public float tweenDuration;
    // Start is called before the first frame update
    void Start()
    {
        Tween();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Tween()
    {
        StartCoroutine(PlayTween());
    }

    IEnumerator PlayTween()
    {
        LeanTween.cancel(gameObject);
        transform.localScale = Vector3.one;
        LeanTween.scale(gameObject, Vector3.one * 1.5f, tweenDuration).setEasePunch();
        yield return new WaitForSeconds(tweenDuration + 1);
    }
}
