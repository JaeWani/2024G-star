using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Item_DragImage : MonoBehaviour
{


    [Header("컴포넌트")]
    [SerializeField]
    public RectTransform rectTransform;
    [SerializeField] private Image image;

    private GraphicRaycaster graphicRaycaster;
    private EventSystem eventSystem;

    [Header("정보")]
    public Item item;
    public Inventory_Item inventory_Item;
    [SerializeField] private Sprite itemSprite;


    [Header("Singleton")]
    private Inventory inventory = Inventory.instance;
    void Start()
    {
        image = GetComponent<Image>();
    }

    void Update()
    {
        Trace();
    }

    public void Init(Item item)
    {
        this.item = item;
        itemSprite = this.item.itemSprite;
        image.sprite = itemSprite;
    }

    public void Drop()
    {
        var obj = inventory.GetPointerObject(rectTransform.position);
        if (obj != null)
        {
            Inventory_Slot slot = obj.GetComponent<Inventory_Slot>();
            if(slot != null) inventory.ItemDrop(slot, inventory_Item, item);
        }
    }

    private void Trace()
    {
        Vector2 mousePos = Input.mousePosition;
        float w = rectTransform.rect.width;
        float h = rectTransform.rect.height;
        rectTransform.position = mousePos + (new Vector2(w, h) * 0.2f);
    }
}
