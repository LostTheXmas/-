using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Events;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEditor;

[ExecuteInEditMode]
[RequireComponent(typeof(Image))]

public class Ui_Button : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    
    public Image targetGraphic;
    public enum VisualMode
    {
        Color,
        Image,
    }
    public VisualMode visualMode = VisualMode.Color;
    [ConditionalHide("_isColorMode", true)]
    [SerializeField]
    private ColorGroup colorGroup = new ColorGroup();
    [ConditionalHide("_isImageMode", true)]
    [SerializeField]
    private ImageGroup imageGroup = new ImageGroup();
    public bool needText = true;
    [ConditionalHide("needText", true)]
    public TextMeshProUGUI textMesh;
    [ConditionalHide("needText", true)]
    public string btnText = "Button";
    [ConditionalHide("needText", true)]
    public Color btnTextColor = new Color(0f, 0f, 0f, 1f);
    public UnityEvent onClick;
    public UnityEvent onEnter;
    public UnityEvent onExit;
    [HideInInspector]
    public bool _isColorMode;
    [HideInInspector]
    public bool _isImageMode;




    private void VisualChange(ButtonEventType type)
    {
        if (visualMode == VisualMode.Color)
        {
            ChangeColor(type);
        }
        else if (visualMode == VisualMode.Image)
        {
            ChangeImage(type);
        }
        
    }
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

    private void ChangeImage(ButtonEventType type)
    {
        switch (type)
        {
            case ButtonEventType.Click:
                targetGraphic.sprite = imageGroup.clickImage;
                    break;
            case ButtonEventType.Enter:
                targetGraphic.sprite = imageGroup.hoveredImage;
                    break;
            case ButtonEventType.Exit:
                targetGraphic.sprite = imageGroup.normalImage;
                    break;
            default:
                break;
        }
    }

    protected void Click()
    {
        VisualChange(ButtonEventType.Click);
        //ChangeImage(ButtonEventType.Click);
        Debug.Log("Click");
        if (onClick.GetPersistentEventCount() > 0)
        {
            onClick.Invoke();
        }
    }
    protected void StartHover()
    {
        VisualChange(ButtonEventType.Enter);
        //ChangeImage(ButtonEventType.Enter);
        Debug.Log("StartHover");
        if (onEnter.GetPersistentEventCount() > 0)
        {
            onEnter.Invoke();
        }
    }
    protected void EndHover()
    {
        VisualChange(ButtonEventType.Exit);
        //ChangeImage(ButtonEventType.Exit);
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
        GetComponent<Image>().alphaHitTestMinimumThreshold = 0.1f;    
    }
    private void VisualModeChange()
    {
        _isColorMode = visualMode ==VisualMode.Color;
        _isImageMode = visualMode == VisualMode.Image;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!Application.isPlaying)
        {
            VisualModeChange();

            if (textMesh != null)
            {
                if (needText)
                {
                    textMesh.enabled = true;
                    textMesh.text = btnText;
                    textMesh.color = btnTextColor;
                }
                else
                {
                    textMesh.enabled = false;
                }
            }

        }
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

