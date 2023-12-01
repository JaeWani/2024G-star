using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject dbuging;

    [Header("Singleton")]
    public static Inventory instance;

    [Header("컴포넌트")]
    public Canvas inventoryCanvas;
    public GraphicRaycaster graphicRaycaster;
    private PointerEventData pointerEventData;
    public EventSystem eventSystem;

    public Camera mainCamera;
    public Image inventoryPanel;
    [SerializeField] private GameObject inventoryContent;
    [Header("인벤토리")]
    public List<Inventory_Item> inventory_Items = new List<Inventory_Item>();
    public List<Item> inventory = new List<Item>();

    [Header("프리펩")]
    [SerializeField] private GameObject inventoryItemPrefab;

    [SerializeField] private Weapon weapon;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        CreatInventoryItem(weapon);
    }

    void Update()
    {

    }

    public void AddInventoryItem(Inventory_Item inventoryItem)
    {
        var item = inventoryItem.item;
        if (item.itemKind == Item.ItemKind.weapon)
        {

        }
    }

    public void CreatInventoryItem(Item item)
    {
        var Inventory_Item = Instantiate(inventoryItemPrefab, inventoryContent.transform).GetComponent<Inventory_Item>();
        Inventory_Item.Init_Item(item);
        inventory_Items.Add(Inventory_Item);
        inventory.Add(Inventory_Item.item);
    }

    public GameObject GetPointerObject(Vector3 pos)
    {
        pointerEventData = new PointerEventData(eventSystem);
        pointerEventData.position = pos;

        List<RaycastResult> results = new List<RaycastResult>();

        graphicRaycaster.Raycast(pointerEventData, results);

        if (results.Count <= 2) return null;
        else return results[2].gameObject;
    }

    public void ItemDrop(Inventory_Slot slot, Inventory_Item inventory_Item, Item item)
    {
        var slotItem = slot.GetItem();

        if (slotItem != null) CreatInventoryItem(slotItem);

        slot.Init_Item(item);

        inventory_Items.Remove(inventory_Item);
        inventory.Remove(item);

        Destroy(inventory_Item.gameObject);
    }
}
