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
        var inventoryItem = Instantiate(inventoryItemPrefab).GetComponent<InventoryItem>();
        inventoryItem.item = weapon;
    }

    void Update()
    {

    }

    public void AddInventoryItem(InventoryItem inventoryItem)
    {
        var item = inventoryItem.item;
        if(item.itemKind == Item.ItemKind.weapon)
        {
            
        }
    }
}
