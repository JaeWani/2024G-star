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
    [SerializeField] private GameObject partsInventoryContent;
    [SerializeField] private GameObject weaponInventoryContent;
    [Header("인벤토리")]
    public List<Parts> partsInventory;
    public List<Weapon> weaponInventory;

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
        var inventoryItem = Instantiate(inventoryItemPrefab, weaponInventoryContent.transform).GetComponent<Inventory_Item>();
        inventoryItem.item = weapon;
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

    public GameObject GetPointerObject(Vector3 pos)
    {
        pointerEventData = new PointerEventData(eventSystem);
        pointerEventData.position = pos;

        List<RaycastResult> results = new List<RaycastResult>();

        graphicRaycaster.Raycast(pointerEventData, results);

        if(results.Count <= 2) return null;
        else return results[2].gameObject;
    }
}
