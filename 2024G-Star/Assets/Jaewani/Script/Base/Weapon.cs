using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon", order = 1)]
public class Weapon : Item
{
    [Header ("정보")]
    public string weaponName;
    public Sprite weaponSprite;

    public GameObject weaponPrefab;
    public IngameWeapon ingameWeapon;

    void Start()
    {

    }

    void Update()
    {
        
    }
}
