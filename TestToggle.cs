using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TestToggle : MonoBehaviour
{
    public Ui_Toggle toggle;
    public TextMeshProUGUI textMeshPro;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (toggle.isOn)
        {
            textMeshPro.text = "Toggle is true";
        }
        else
        {
            textMeshPro.text = "Toggle is false";
        }
    }
}
