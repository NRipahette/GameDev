using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectList : MonoBehaviour
{
    public GameObject Effect1;
    public GameObject Effect2;
    public GameObject Effect3;
    private SpellDatabase TheSpellDatabase;
    private InventoryManager PlayerInventory;

    public void Start()
    {
        TheSpellDatabase = FindObjectOfType<SpellDatabase>();
        PlayerInventory = FindObjectOfType<InventoryManager>();
    }

    public GameObject GetEffect()
    {
        if (PlayerInventory.equipped == 1)
            return Effect1;
        else if (PlayerInventory.equipped == 2)
            return Effect2;
        else return null;
    }
}
