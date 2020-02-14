using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float TotalHealthPoints = 10;
    public float CurrentHealthPoints = 10;
    private float current_speed = 1;
    private float turning_speed = 0.1f;
    private float NormalMovementSpeed = 1;
    private float AttackMovementSpeed = 0.2f;
    internal bool IsAlive = true;
    // Start is called before the first frame update
    void Start()
    {
        IsAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(CurrentHealthPoints <= 0)
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


    internal void SetAttackMovementSpeed()
    {
        current_speed = AttackMovementSpeed;
    }

    internal void SetNormalMovementSpeed()
    {
        current_speed = NormalMovementSpeed;
    }
}
