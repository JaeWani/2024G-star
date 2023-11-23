using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Inventory_Item : MonoBehaviour
{

    [Header ("Singleton")]
    public Inventory inventory = Inventory.instance;

    [Header("상태")]
    public Item item;
    [SerializeField] private Item_DragImage dragImage;
    [Header("프리펩")]
    [SerializeField] private GameObject itemDragImage;
    void Start()
    {

    }

    void Update()
    {

    }

    public void OnDragBegin(BaseEventData baseEventData)
    {
        if (item != null)
        {
            dragImage = Instantiate(itemDragImage, transform.position, Quaternion.identity).GetComponent<Item_DragImage>();

            dragImage.Init(item.itemSprite);
            dragImage.transform.SetParent(Inventory.instance.inventoryPanel.transform, false);
            dragImage.transform.SetAsLastSibling();
            dragImage.transform.localPosition = transform.localPosition;
        }
    }

    public void OnDrag(BaseEventData baseEventData)
    {
        if (dragImage != null)
        {
            PointerEventData pointerEventData = (PointerEventData)baseEventData;
            dragImage.rectTransform.localPosition = pointerEventData.position;
            Debug.Log("dragImage = " + dragImage.transform.localPosition);
            Debug.Log("pointer = " + pointerEventData.position);
        }
    }

    public void OnDragEnd(BaseEventData baseEventData)
    {
        if (dragImage != null)
        {
            dragImage.Drop();
            //Destroy(dragImage.gameObject);
            dragImage = null;
        }
    }
}
