using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float TotalHealthPoints = 10;
    public float CurrentHealthPoints = 10;
    private Animator myAnimator;
    internal bool IsAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponentInChildren<Animator>();
        myAnimator.SetBool("IsAlive", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentHealthPoints <= 0)
        { IsAlive = false; }

        if (!IsAlive)
        {
            Destroy(gameObject);
        }
    }


    public void Damaged(float damage)
    {
        CurrentHealthPoints -= damage;
    }


    bool CheckIsAlive()
    {
        GetComponent<Animator>().SetBool("IsAlive", IsAlive);
        return IsAlive;
    }
}
