using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellDatabase : MonoBehaviour
{

   
    public List<Spell> SpellList = new List<Spell>();

    private void Start()
    {
        for(int i = 0; i<= SpellList.Count; i++)
        {
            Instantiate(SpellList[i].Effect);
        }
    }
    public float GetDamage( int id)
    {
        return SpellList[id].Base_Damage;
    }

    public GameObject GetEffect(int id)
    {
        return SpellList[id].Effect;
    }

    public string GetName(int id)
    {
        return SpellList[id].Name;
    }
}
