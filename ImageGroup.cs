using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Serialization;
[Serializable]
public class ImageGroup 
{
    [SerializeField]
    private Sprite _normalImage;
    public Sprite normalImage => _normalImage;

    [SerializeField]
    private Sprite _hoveredImage;
    public Sprite hoveredImage => _hoveredImage;

    [SerializeField]
    private Sprite _clickImage;
    public Sprite clickImage => _clickImage;

}
