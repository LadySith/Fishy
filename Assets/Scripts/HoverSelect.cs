using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using Tobii.Gaming;
public class HoverSelect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject Image;
    private IEnumerator coroutine;
    public Button thisButton;
    public GameObject focus;

    private bool isCoroutinestarted;

    // Start is called before the first frame update
    void Start()
    {
        Image.transform.localScale = Vector3.zero;
        isCoroutinestarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (TobiiAPI.IsConnected && NUIManager.Instance.typeOfNUI == 2)
        {
            GameObject focusedObject = TobiiAPI.GetFocusedObject();
            if (null != focusedObject && focusedObject == focus)
            {
                print("The focused game object is: " + focus.name);
                if (focus.tag == "LeftSphere")
                {
                    if (!isCoroutinestarted)
                    {
                        LeanTween.scale(Image, Vector3.one, 3f).setEaseOutQuad();
                        coroutine = CountToSelect();
                        StartCoroutine(coroutine);
                    }
                }

                if (focus.tag == "RightSphere")
                {
                    if (!isCoroutinestarted)
                    {
                        LeanTween.scale(Image, Vector3.one, 3f).setEaseOutQuad();
                        coroutine = CountToSelect();
                        StartCoroutine(coroutine);
                    }
                }

                if (focus.tag == "TopSphere")
                {
                    if (!isCoroutinestarted)
                    {
                        LeanTween.scale(Image, Vector3.one, 3f).setEaseOutQuad();
                        coroutine = CountToSelect();
                        StartCoroutine(coroutine);
                    }
                }
            }
            else
            {
                if (coroutine != null)
                {
                    StopCoroutine(coroutine);
                }
                isCoroutinestarted = false;
                LeanTween.cancel(Image);
                LeanTween.scale(Image, Vector3.zero, 0.5f).setEaseOutExpo();
            }
        }
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (NUIManager.Instance.typeOfNUI == 2)
        {
            LeanTween.scale(Image, Vector3.one, 3f).setEaseOutQuad();
            coroutine = CountToSelect();
            StartCoroutine(coroutine);
        }

        else
        {
            LeanTween.scale(Image, Vector3.zero, 0.5f).setEaseOutExpo();
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (NUIManager.Instance.typeOfNUI == 2)
        {
            StopCoroutine(coroutine);
            LeanTween.cancel(Image);
            LeanTween.scale(Image, Vector3.zero, 0.5f).setEaseOutExpo();
        }

        else
        {
            LeanTween.scale(Image, Vector3.zero, 0.5f).setEaseOutExpo();
        }
    }
    IEnumerator CountToSelect()
    {
        isCoroutinestarted = true;
        yield return new WaitForSeconds(3);
        Image.transform.localScale = Vector3.zero;
        thisButton.onClick.Invoke();
    }
}
