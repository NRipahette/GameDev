using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float TotalHealthPoints = 10;
    public float CurrentHealthPoints = 10;
    private float current_speed = 1;
    private float turning_speed = 0.1f;
    private float NormalMovementSpeed = 1;
    private float AttackMovementSpeed = 0.2f;
    private Animator myAnim;
    public GameObject Target;
    private NavMeshAgent navMesh;
    internal bool IsAlive = true;
    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
        myAnim.SetBool("IsAlive", true);
        navMesh = GetComponent<NavMeshAgent>();
        CheckTargets();
    }

    // Update is called once per frame
    void Update()
    {
        CheckIsAlive();
        if (IsAlive)
        {
            if (CurrentHealthPoints <= 0)
            {
                IsAlive = false;
                navMesh.isStopped = true;
            }
            if (!myAnim.GetBool("IsHit"))
                MoveToTarget();
            else
            {
                
            }
        }
        else
        {
            navMesh.isStopped = true;

        }
        //if (!IsAlive )
        //{
        //    Destroy(gameObject);
        //}

    }

    public void Damaged(float damage)
    {
        CurrentHealthPoints -= damage;
    }
    private void Stop() {
        navMesh.isStopped=true;
    }

    public void CheckTargets() {
       Target =  GameObject.FindGameObjectWithTag("Player"); ;
    }

    public void MoveToTarget() {
        gameObject.GetComponent<NavMeshAgent>().destination = Target.transform.position;
        if (Vector3.Distance(transform.position , Target.transform.position) <= 5 && IsAlive)
            navMesh.isStopped = false;
        else
        {
            navMesh.isStopped = true;
        }
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
