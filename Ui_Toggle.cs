using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEditor.Events;
using UnityEngine.Events;
using UnityEngine.UI;

[ExecuteInEditMode]
public class Ui_Toggle : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public ColorGroup colorGroup;
    public TextMeshProUGUI label;
    public Color textColor = new Color(0f, 0f, 0f, 1f);
    public string text = "Toggle";

    public bool isOn;
    public Image background;
    public Image graphic;
    public UnityEvent onClick;
    public UnityEvent onEnter;
    public UnityEvent onExit;

    public void OnEnable()
    {
        if (!Application.isPlaying)
        {

        }
    }

    private void ColorChange(ToggleEvent type)
    {
        switch (type)
        {
            case ToggleEvent.Click:
                background.color = colorGroup.clickColor;
                break;
            case ToggleEvent.Enter:
                background.color = colorGroup.hoveredColor;
                break;
            case ToggleEvent.Exit:
                background.color = colorGroup.normalColor;
                break;
        }
    }

    protected void OnClick()
    {
        if (isOn)
        {
            isOn = false;
        }
        else
        {
            isOn = true;
        }
        ColorChange(ToggleEvent.Click);
        if (onClick.GetPersistentEventCount() > 0)
        {
            onClick.Invoke();
        }
                
    }
    protected void OnEnter()
    {
        ColorChange(ToggleEvent.Enter);
        if (onEnter.GetPersistentEventCount() > 0)
        {
            onEnter.Invoke();
        }
    }
    protected void OnExit()
    {
        ColorChange(ToggleEvent.Exit);
        if (onExit.GetPersistentEventCount() > 0)
        {
            onExit.Invoke();
        }
    }
    void Start()
    {
        
    }
    void Update()
    {
        if (graphic != null && label != null && background != null)
        {
            graphic.enabled = isOn;
            if (!Application.isPlaying)
            {
                label.color = textColor;
                label.text = text;
            }
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        OnClick();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        OnEnter();
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        OnExit();
    }
}
