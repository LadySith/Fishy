using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenScripts : MonoBehaviour
{
    public float tweenDuration;

    GameObject mainMenu;
    GameObject touchButton;
    GameObject touchMenu;
    GameObject beginTouch;
    GameObject backTouch;
    GameObject eyeButton;
    GameObject eyeMenu;
    GameObject beginEye;
    GameObject backEye;

    // Start is called before the first frame update
    void Start()
    {
        touchButton = GameObject.FindGameObjectWithTag("touchButton");
        touchMenu = GameObject.FindGameObjectWithTag("touchMenu");
        beginTouch = GameObject.FindGameObjectWithTag("beginTouch");
        backTouch = GameObject.FindGameObjectWithTag("backTouch");
        touchMenu.SetActive(false);
        eyeButton = GameObject.FindGameObjectWithTag("eyeButton");
        eyeMenu = GameObject.FindGameObjectWithTag("eyeMenu");
        beginEye = GameObject.FindGameObjectWithTag("beginEye");
        backEye = GameObject.FindGameObjectWithTag("backEye");
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
        touchMenu.transform.localScale = Vector3.zero;
        touchMenu.SetActive(true);
        StartCoroutine(OpenTouchPanel());
        mainMenu.SetActive(false);

    }

    IEnumerator OpenTouchPanel()
    {
        LeanTween.scale(touchMenu, Vector3.one, tweenDuration/2);
        yield return new WaitForSeconds(tweenDuration/2);
        touchMenu.transform.localScale = Vector3.one;
    }

    IEnumerator CloseTouchPanel()
    {
        mainMenu.SetActive(true);
        LeanTween.scale(touchMenu, Vector3.zero, tweenDuration / 2);
        yield return new WaitForSeconds(tweenDuration / 2);
        touchMenu.transform.localScale = Vector3.zero;
        touchMenu.SetActive(false);
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
        eyeMenu.transform.localScale = Vector3.zero;
        eyeMenu.SetActive(true);
        StartCoroutine(OpenEyePanel());
        mainMenu.SetActive(false);
    }

    IEnumerator OpenEyePanel()
    {
        LeanTween.scale(eyeMenu, Vector3.one, tweenDuration / 2);
        yield return new WaitForSeconds(tweenDuration / 2);
        eyeMenu.transform.localScale = Vector3.one;
    }

    IEnumerator CloseEyePanel()
    {
        mainMenu.SetActive(true);
        LeanTween.scale(eyeMenu, Vector3.zero, tweenDuration / 2);
        yield return new WaitForSeconds(tweenDuration / 2);
        eyeMenu.transform.localScale = Vector3.zero;
        eyeMenu.SetActive(false);
    }

    public void BeginTouch()
    {

    }

    public void BeginEye()
    {

    }

    public void BackTouch()
    {
        StartCoroutine(PlayBackTouch());
    }

    public void BackEye()
    {
        StartCoroutine(PlayBackEye());
    }

    IEnumerator PlayBackEye()
    {
        LeanTween.cancel(backEye); //make sure this references the correct object when needed
        backEye.transform.localScale = Vector3.one;
        LeanTween.scale(backEye, Vector3.one * 1.2f, tweenDuration).setEasePunch();
        yield return new WaitForSeconds(tweenDuration + 0.5f);
        StartCoroutine(CloseEyePanel());
    }

    IEnumerator PlayBackTouch()
    {
        LeanTween.cancel(backTouch); //make sure this references the correct object when needed
        backTouch.transform.localScale = Vector3.one;
        LeanTween.scale(backTouch, Vector3.one * 1.2f, tweenDuration).setEasePunch();
        yield return new WaitForSeconds(tweenDuration + 0.5f);
        StartCoroutine(CloseTouchPanel());
    }
}
