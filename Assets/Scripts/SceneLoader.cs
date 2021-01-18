using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadTouchGame()
    {
        NUIManager.Instance.typeOfNUI = 1;
        NUIManager.Instance.someWord = "Tap the screen";
        SceneManager.LoadScene("Main Game");

        Debug.Log("Opened Touch Game");
        Debug.Log("Type of NUI = " + NUIManager.Instance.typeOfNUI.ToString());
        Debug.Log("Instructions: " + NUIManager.Instance.someWord);
    }

    public void LoadEyeGame()
    {
        NUIManager.Instance.typeOfNUI = 2;
        NUIManager.Instance.someWord = "Look around the pond";
        SceneManager.LoadScene("Main Game");

        Debug.Log("Opened Eye-Tracking Game");
        Debug.Log("Type of NUI = " + NUIManager.Instance.typeOfNUI.ToString());
        Debug.Log("Instructions: " + NUIManager.Instance.someWord);
    }

    public void LoadHomeScreen()
    {
        SceneManager.LoadScene("Menu Scene");
        Debug.Log("ET phone home");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game!");
    }
}
