using UnityEngine;
using UnityEngine.UI;
using System;

[RequireComponent(typeof(RectTransform))]

public class Item : MonoBehaviour
{
    [SerializeField] private Image _image;

    private RectTransform _rectTransform;

    public bool IsVisible {get; private set;}
    public bool IsAboveScreenBottom => _rectTransform.position.y + _rectTransform.rect.height / 2 > 0;

    private void OnEnable()
    {
        _rectTransform = GetComponent<RectTransform>();
        IsVisible = false;
    }

    public void Init(Sprite sprite)
    {
        _image.sprite = sprite;
    }    

    public void SetVisible()
    {
        if (IsAboveScreenBottom == false)
        {
            throw new Exception("Объект слишком низко, и не может быть видимым.");
        }

        IsVisible = true;
    }
}
