using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TweenScripts : MonoBehaviour
{
    public float tweenDuration;
    public Animator transition;

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
        NUIManager.Instance.typeOfNUI = 1;
        NUIManager.Instance.someWord = "Tap the screen";
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
        NUIManager.Instance.typeOfNUI = 2;
        NUIManager.Instance.someWord = "Look around";
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
        StartCoroutine(PlayBeginTouch());
    }

    public void BeginEye()
    {
        StartCoroutine(PlayBeginEye());
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

    IEnumerator PlayBeginEye()
    {
        LeanTween.cancel(beginEye); //make sure this references the correct object when needed
        beginEye.transform.localScale = Vector3.one;
        LeanTween.scale(beginEye, Vector3.one * 1.2f, tweenDuration).setEasePunch();
        yield return new WaitForSeconds(tweenDuration + 0.5f);
        StartCoroutine(TransitionToEye());
    }

    IEnumerator TransitionToEye()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(0.8f);
        SceneManager.LoadScene("Main Game");
        Debug.Log("Starting Game With Eye-Tracking");
    }

    IEnumerator PlayBeginTouch()
    {
        LeanTween.cancel(beginTouch); //make sure this references the correct object when needed
        beginTouch.transform.localScale = Vector3.one;
        LeanTween.scale(beginTouch, Vector3.one * 1.2f, tweenDuration).setEasePunch();
        yield return new WaitForSeconds(tweenDuration + 0.5f);
        StartCoroutine(TransitionToTouch());
    }

    IEnumerator TransitionToTouch()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(0.8f);
        SceneManager.LoadScene("Main Game");
        Debug.Log("Starting Game With Touch");
    }
}
