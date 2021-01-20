using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Tobii.Gaming;

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
    Text overText;

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
        overText = GameObject.Find("OverheadText").GetComponent<Text>();
        overText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (TobiiAPI.IsConnected && NUIManager.Instance.typeOfNUI == 2)
        {
            NUIManager.Instance.someWord = "Eyetracker detected";
            overText.text = NUIManager.Instance.someWord;
        }

        if ((!TobiiAPI.IsConnected) && NUIManager.Instance.typeOfNUI == 2)
        {
            NUIManager.Instance.someWord = "No eyetracker detected - Mouse override";
            overText.text = NUIManager.Instance.someWord;
        }

    }

    public void SelectTouch()
    {
        FindObjectOfType<MusicManager>().PlaySound("Drop"); //Play Drop sound from MusicManager sound array
        StartCoroutine(PlaySelectTouch());
        NUIManager.Instance.typeOfNUI = 1;
        NUIManager.Instance.someWord = "Touch Mode";
        overText.text = NUIManager.Instance.someWord;
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
        FindObjectOfType<MusicManager>().PlaySound("Drop"); //Play Drop sound from MusicManager sound array
        StartCoroutine(PlaySelectEye());
        NUIManager.Instance.typeOfNUI = 2;
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
        FindObjectOfType<MusicManager>().PlaySound("Drop"); //Play Drop sound from MusicManager sound array
        StartCoroutine(PlayBeginTouch());
    }

    public void BeginEye()
    {
        FindObjectOfType<MusicManager>().PlaySound("Drop"); //Play Drop sound from MusicManager sound array
        StartCoroutine(PlayBeginEye());
    }

    public void BackTouch()
    {
        FindObjectOfType<MusicManager>().PlaySound("Drop"); //Play Drop sound from MusicManager sound array
        StartCoroutine(PlayBackTouch());
    }

    public void BackEye()
    {
        FindObjectOfType<MusicManager>().PlaySound("Drop"); //Play Drop sound from MusicManager sound array
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

    //Cyan background button stuff

}
