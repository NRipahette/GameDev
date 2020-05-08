using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour, IHealth
{
    public float TotalHealthPoints = 10;
    public float CurrentHealthPoints = 10;
    private float current_speed = 1;
    private float turning_speed = 0.1f;
    private float NormalMovementSpeed = 1;
    private float AttackMovementSpeed = 0.2f;
    private Animator myAnim;
    public GameObject Target;
    private Collider enemycollider;
    private NavMeshAgent navMesh;
    private string currentState;
    internal bool IsAlive;

    private SpellDatabase TheSpellDatabase;
    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
        myAnim.SetBool("IsAlive", true);
        enemycollider = GetComponent<Collider>();
        navMesh = GetComponent<NavMeshAgent>();
        currentState = "idle";
        TheSpellDatabase = FindObjectOfType<SpellDatabase>();
        CheckTargets();
    }

    // Update is called once per frame
    void Update()
    {
        //if (!IsAlive )
        //{
        //    Destroy(gameObject);
        //}
        //Debug.Log(Vector3.Distance(transform.position, Target.transform.position));
        //Debug.Log(currentState);
        CheckIsAlive();

        switch (currentState)
        {
            case "Idle":
                CheckTargets();
                navMesh.isStopped = true;
                gameObject.GetComponent<NavMeshAgent>().destination = Target.transform.position;
                if (Vector3.Distance(transform.position, Target.transform.position) <= 10 && IsAlive)
                {
                    currentState = "Moving";
                }
                break;
            case "Moving":
                navMesh.isStopped = false;
                gameObject.GetComponent<NavMeshAgent>().destination = Target.transform.position;
                if (Vector3.Distance(transform.position, Target.transform.position) > 20 && IsAlive)
                {
                    currentState = "Idle";
                }

                break;
            case "Hit":
                navMesh.isStopped = true;
                break;
            case "Dead":
                IsAlive = false;
                navMesh.isStopped = true;
                Destroy(enemycollider);
                StartCoroutine(StopRagdoll());
                break;
        }
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

    public IEnumerator StopRagdoll()
    {
        yield return new WaitForSeconds(2);
        GetComponent<Rigidbody>().isKinematic = true;
    }

    public IEnumerator IsHit()
    {
        currentState = "Hit";
        yield return new WaitForSeconds(2);
        currentState = "Idle";

    }


    public bool CheckIsAlive()
    {
        if (CurrentHealthPoints <= 0 )
        {
            IsAlive = false;
            currentState = "Dead";
        }
        else
        {
            IsAlive = true;
        }
        GetComponent<Animator>().SetBool("IsAlive", IsAlive);
        return IsAlive;
    }

    public void Damage(float damage)
    {
        CurrentHealthPoints -= damage;
        StartCoroutine(IsHit());
    }

    public void DamagedBySpell(int spellId)
    {
        CurrentHealthPoints -= TheSpellDatabase.SpellList[spellId].Base_Damage;
        StartCoroutine(IsHit());
    }

    //public void DamagedBySplashSpell(int spellId)
    //{
    //    CurrentHealthPoints -= (TheSpellDatabase.SpellList[spellId].Base_Damage * 0.7f);
    //}



    internal void SetAttackMovementSpeed()
    {
        current_speed = AttackMovementSpeed;
    }

    internal void SetNormalMovementSpeed()
    {
        current_speed = NormalMovementSpeed;
    }

}
