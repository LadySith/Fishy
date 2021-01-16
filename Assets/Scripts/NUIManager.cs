using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NUIManager : MonoBehaviour
{
    public static NUIManager Instance { get; private set; }

    public int typeOfNUI; //1 = Touch, 2 = Eye-tracking
    public string someWord;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
