using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour , IHealth
{
    public float TotalHealthPoints = 10;
    public float CurrentHealthPoints = 10;
    public int equipped;
    private Animator myAnimator;
    internal bool IsAlive = true;
    private SpellDatabase TheSpellDatabase;



    // Start is called before the first frame update
    void Start()
    {
        TheSpellDatabase = FindObjectOfType<SpellDatabase>();
        myAnimator = GetComponentInChildren<Animator>();
        myAnimator.SetBool("IsAlive", true);
    }

    // Update is called once per frame
    void Update()
    {
        

        /*if (!IsAlive)
        {
            Destroy(gameObject);
        }*/
    }


    public void Damage(float damage)
    {
        CurrentHealthPoints -= damage;
    }


    public bool CheckIsAlive()
    {
        GetComponent<Animator>().SetBool("IsAlive", IsAlive);
        if (CurrentHealthPoints <= 0)
        { IsAlive = false; }
        else
        {
            IsAlive = true;
        }
        return IsAlive;
    }

    public void DamagedBySpell(int spellId)
    {
        CurrentHealthPoints -= TheSpellDatabase.SpellList[spellId].Base_Damage;
    }
}
