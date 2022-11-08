using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Events;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[ExecuteInEditMode]
[RequireComponent(typeof(Image))]
public class Ui_Button :MonoBehaviour,  IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    
    public Image targetGraphic;
    public ColorGroup colorGroup;

    public UnityEvent onClick;
    public UnityEvent onEnter;
    public UnityEvent onExit;

    private void ChangeColor(ButtonEventType type)
    {
        switch (type)
        {
            case ButtonEventType.Click:
                targetGraphic.color = colorGroup.clickColor; 
                    break;
            case ButtonEventType.Enter:
                targetGraphic.color = colorGroup.hoveredColor;
                    break;
            case ButtonEventType.Exit:
                targetGraphic.color = colorGroup.normalColor;
                    break;

        }
    }

    protected void Click()
    {
        ChangeColor(ButtonEventType.Click);
        Debug.Log("Click");
        if (onClick.GetPersistentEventCount() > 0)
        {
            onClick.Invoke();
        }
    }
    protected void StartHover()
    {
        ChangeColor(ButtonEventType.Enter);
        Debug.Log("StartHover");
        if (onEnter.GetPersistentEventCount() > 0)
        {
            onEnter.Invoke();
        }
    }
    protected void EndHover()
    {
        ChangeColor(ButtonEventType.Exit);
        Debug.Log("EndHover");
        if (onExit.GetPersistentEventCount() > 0)
        {
            onExit.Invoke();
        }

    }
    public void AddListener(ButtonEventType type, UnityAction callBack)
    {
        if (type == ButtonEventType.Enter)
        {
            UnityEventTools.AddPersistentListener(onEnter, callBack);
        }
        else if (type == ButtonEventType.Exit)
        {
            UnityEventTools.AddPersistentListener(onExit, callBack);
        }
        else if(type == ButtonEventType.Click)
        {
            UnityEventTools.AddPersistentListener(onClick, callBack);
        }
    }

    public void OnEnable()
    {
        if (!Application.isPlaying)
        {
            targetGraphic = GetComponent<Image>();
        }
        else
        {

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Click();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        StartHover();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        EndHover();
    }
}

