using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    private Inventory inventory = Inventory.instance;

    public Item item;

    void Start()
    {
        inventory.AddInventoryItem(this);
    }

    void Update()
    {
        
    }
}
