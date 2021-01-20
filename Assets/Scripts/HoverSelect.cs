using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class HoverSelect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject Image;
    private IEnumerator coroutine;
    //private bool tweening;

    // Start is called before the first frame update
    void Start()
    {
        Image.transform.localScale = Vector3.zero;
        //tweening = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if (IsMouseOverButton())
        //{
        //    tweening = true;
        //    LeanTween.scale(Image, Vector3.one, 3f).setEasePunch();
        //}

        //if (tweening && !IsMouseOverButton())
        //{
        //    LeanTween.scale(Image, Vector3.zero, 0.5f);
        //    Image.transform.localScale = Vector3.zero;
        //    tweening = false;
        //}
        
    }

    //private bool IsMouseOverButton()
    //{
    //    return EventSystem.current.IsPointerOverGameObject();
    //}

    //private void OnMouseExit()
    //{
    //    LeanTween.cancel(Image);
    //    //Image.transform.localScale = Vector3.zero;
    //}

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (NUIManager.Instance.typeOfNUI == 2)
        {
            LeanTween.scale(Image, Vector3.one, 3f).setEaseOutQuad();
            //Debug.Log("Pointer Entered Button: " + gameObject.name);
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
            //Debug.Log("Pointer Exited Button: " + gameObject.name);
        }

        else
        {
            LeanTween.scale(Image, Vector3.zero, 0.5f).setEaseOutExpo();
        }
    }

    IEnumerator CountToSelect()
    {
        yield return new WaitForSeconds(3);
        if (this.gameObject.name == "TouchButton")
        {
            Debug.Log("Touch Button Pressed");
        }

        if (this.gameObject.name == "EyeButton")
        {
            Debug.Log("Eye Button Pressed");
        }

    }

}
