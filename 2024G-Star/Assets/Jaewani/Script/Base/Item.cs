using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item", order = 1)]
public class Item : ScriptableObject
{
    public enum Kind
    {
        Sword,
        Staff,
        Gun,
        Throw
    }
    public enum ItemKind
    {
        parts,
        weapon
    }
    
    public ItemKind itemKind;
    public Kind kind;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
