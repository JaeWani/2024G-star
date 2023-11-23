using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    [Header("Singleton")]
    public static Inventory instance;

    [Header("UI")]
    public Canvas mainCanvas;
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
        if(item.itemKind == Item.ItemKind.weapon)
        {
            
        }
    }
}
