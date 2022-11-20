using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
public class ItemScr : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private CanvasGroup canvasGroup;
    public GameObject panel;
    public GameObject bag;

    private GameObject placeholder;
    int i;
    public void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }
public void OnBeginDrag(PointerEventData eventData)
    {
        placeholder = new GameObject();
        placeholder.transform.SetParent(this.transform.parent);
        LayoutElement le = placeholder.AddComponent<LayoutElement>();
        le.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
        le.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;

        placeholder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());
        this.transform.SetParent(panel.transform);

    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
        canvasGroup.blocksRaycasts = false;

        if (eventData.position.y < 150)
            i = 9;
        else
            i = 0;
        while(i < bag.transform.childCount)
        {          
            if(this.transform.position.x < bag.transform.GetChild(i).position.x)
            {
                placeholder.transform.SetSiblingIndex(i);

                break;
            }
            i++;
        }

        if (eventData.position.y < 255)
        {
            this.transform.SetParent(bag.transform);
            placeholder.transform.SetParent(bag.transform);
        }

        else
        {
            this.transform.SetParent(panel.transform);
            placeholder.transform.SetParent(panel.transform);
        }

        Debug.Log(eventData.position);

    }
    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
        canvasGroup.blocksRaycasts = true;
        this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
        Destroy(placeholder);

    }
}
