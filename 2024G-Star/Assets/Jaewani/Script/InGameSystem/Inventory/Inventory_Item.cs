using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Inventory_Item : MonoBehaviour
{

    [Header("Singleton")]
    public Inventory inventory = Inventory.instance;

    [Header("상태")]
    public Item item;
    [SerializeField] private Item_DragImage dragImage;

    [Header("프리펩")]
    [SerializeField] private GameObject itemDragImage;

    [Header ("컴포넌트")]
    [SerializeField] private Image image;
    void Start()
    {
    }

    void Update()
    {

    }
    public void Init_Item(Item item)
    {
        this.item = item;
        image.sprite = item.itemSprite;
        Debug.Log("tprtm");
    }

    public void OnDragBegin(BaseEventData baseEventData)
    {
        if (item != null)
        {
            dragImage = Instantiate(itemDragImage, transform.position, Quaternion.identity).GetComponent<Item_DragImage>();

            dragImage.Init(item);
            dragImage.inventory_Item = this;
            dragImage.transform.SetParent(Inventory.instance.inventoryPanel.transform, false);
            dragImage.transform.SetAsLastSibling();
            dragImage.transform.localPosition = transform.localPosition;
        }
    }

    public void OnDragEnd(BaseEventData baseEventData)
    {
        if (dragImage != null)
        {
            dragImage.Drop();
            Destroy(dragImage.gameObject);
            dragImage = null;
        }
    }
}
