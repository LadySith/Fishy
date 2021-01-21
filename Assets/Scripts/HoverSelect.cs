using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
public class HoverSelect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject Image;
    private IEnumerator coroutine;
    public Button thisButton;

    // Start is called before the first frame update
    void Start()
    {
        Image.transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        
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
        yield return new WaitForSeconds(3);
        Image.transform.localScale = Vector3.zero;
        thisButton.onClick.Invoke();
    }
}
