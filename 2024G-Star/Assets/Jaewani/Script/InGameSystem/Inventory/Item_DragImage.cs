using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Item_DragImage : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Sprite itemSprite;
    public RectTransform rectTransform;
    void Start()
    {
    }

    void Update()
    {

    }

    public void Init(Sprite sprite)
    {
        itemSprite = sprite;
        image.sprite = sprite;
    }

    public void Drop()
    {

    }
}
