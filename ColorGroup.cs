using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


[Serializable]
public class ColorGroup 
{

    [SerializeField]
    private Color _normalColor = Color.white;
    public Color normalColor => _normalColor;

    [SerializeField]
    private Color _hoveredColor = new Color(0.84f, 0.84f, 0.84f, 1f);
    public Color hoveredColor => _hoveredColor;

    [SerializeField]
    private Color _clickColor = new Color(0.78f, 0.78f, 0.78f, 1f);
    public Color clickColor => _clickColor;

    [SerializeField]
    private Color _disabledColor = new Color(0.78f, 0.78f, 0.78f, 0.5f);
    public Color disabledColor => _disabledColor;

}
