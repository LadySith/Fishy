using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenScripts : MonoBehaviour
{
    public float tweenDuration;

    GameObject mainMenu;
    GameObject touchButton;
    GameObject touchMenu;
    GameObject eyeButton;
    GameObject eyeMenu;

    // Start is called before the first frame update
    void Start()
    {
        touchButton = GameObject.FindGameObjectWithTag("touchButton");
        touchMenu = GameObject.FindGameObjectWithTag("touchMenu");
        touchMenu.SetActive(false);
        eyeButton = GameObject.FindGameObjectWithTag("eyeButton");
        eyeMenu = GameObject.FindGameObjectWithTag("eyeMenu");
        eyeMenu.SetActive(false);
        mainMenu = GameObject.FindGameObjectWithTag("mainMenu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectTouch()
    {
        StartCoroutine(PlaySelectTouch());
    }

    IEnumerator PlaySelectTouch()
    {
        LeanTween.cancel(touchButton); //make sure this references the correct object when needed
        touchButton.transform.localScale = Vector3.one;
        LeanTween.scale(touchButton, Vector3.one * 1.2f, tweenDuration).setEasePunch();
        yield return new WaitForSeconds(tweenDuration + 0.5f);
        touchMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void SelectEye()
    {
        StartCoroutine(PlaySelectEye());
    }

    IEnumerator PlaySelectEye()
    {
        LeanTween.cancel(eyeButton); //make sure this references the correct object when needed
        eyeButton.transform.localScale = Vector3.one;
        LeanTween.scale(eyeButton, Vector3.one * 1.2f, tweenDuration).setEasePunch();
        yield return new WaitForSeconds(tweenDuration + 0.5f);
        eyeMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void BeginTouch()
    {

    }

    public void BeginEye()
    {

    }

    public void BackTouch()
    {

    }

    public void BackEye()
    {

    }
}
