using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestText : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI textMeshPro;
    public Ui_Button ui_Button;

    void Start()
    {
        if (ui_Button == null)
        {
            Debug.Log("Ui_Button is null");
        }
        else
        {
            ui_Button.AddListener(ButtonEventType.Click,OnClick);
            ui_Button.AddListener(ButtonEventType.Enter, OnEnter);
            ui_Button.AddListener(ButtonEventType.Exit, OnExit);
        }
    }
    private void OnClick()
    {
        textMeshPro.text = "OnClick";
    }
    private void OnEnter()
    {
        textMeshPro.text = "OnEnter";
    }
    private void OnExit()
    {
        textMeshPro.text = "OnExit";
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
