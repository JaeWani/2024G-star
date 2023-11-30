using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_Slot : MonoBehaviour
{
    [Header("정보")]
    [SerializeField] private Item item;

    [Header ("컴포넌트")]
    [SerializeField] private Image item_Image;

    void Start()
    {

    }

    void Update()
    {

    }

    public void Init_Item(Item item)
    {
        this.item = item;
        item_Image.sprite = item.itemSprite;
        Debug.Log("Init");
    }
}
