using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public int[] inventory = new int[3];
    public Spell1 current;
    public Spell weapon2;
    public Animator myAnimator;
    public int equipped;
    internal Text displayItem;
    public SpellDatabase theDatabase;
    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponentInChildren<Animator>();
        theDatabase = GameObject.Find("GameManager").GetComponent<SpellDatabase>();
        displayItem = GameObject.Find("SpellText").GetComponent<Text>();
        equipped = inventory[0];
    }

    // Update is called once per frame
    void Update()
    {
        myAnimator.SetLayerWeight(2, 1);

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            equipped = inventory[0];
        }else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            equipped = inventory[1];
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            current.TriggerEffect();
        }

        displayItem.text = theDatabase.GetName(equipped);

    }


    public int CheckWeaponId()
    {
        return current.SpellID;
    }
}
