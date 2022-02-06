using System;
using UnityEngine;
using UnityEngine.UI;

public class ToggleSprite : MonoBehaviour
{
    [SerializeField] private Toggle toggle;
    [SerializeField] private Image image;
    
    [SerializeField] private Sprite spriteOn;
    [SerializeField] private Sprite spriteOff;
    
    public void Toggle()
    {
        image.sprite = toggle.isOn ? spriteOn : spriteOff;
    }
}
