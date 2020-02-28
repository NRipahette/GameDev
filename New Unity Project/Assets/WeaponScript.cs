using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public float Damage = 7;
    private SphereCollider WeaponCollider;
    private GameObject Player;
    //private BoxCollider PlayerCollider;
    private Animator myAnim;
    private bool IsAttacking =false;
    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponentInParent<Animator>();
        //PlayerCollider = GetComponent<BoxCollider>();
        WeaponCollider = GetComponent<SphereCollider>();
        Player = WeaponCollider.gameObject;
        WeaponCollider.enabled = false;
        //Physics.IgnoreCollision(WeaponCollider, PlayerCollider);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            slash();

        }
    }

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision.gameObject.name);
        //if (collision.transform.tag == "Enemy")
        //if (myAnim.GetBool("IsAttacking") == true)
       // {
            if (collision.gameObject.CompareTag("Enemy") && !collision.GetComponent<Animator>().GetBool("IsHit"))
            {
                collision.transform.GetComponent<EnemyController>().Damaged(Damage);
                collision.GetComponent<Animator>().SetBool("IsHit", true);
                WeaponCollider.enabled = false;

            }
            if (collision.gameObject.CompareTag("Player"))
            {
                Physics.IgnoreCollision(collision, WeaponCollider);
                collision.transform.GetComponent<EnemyController>().Damaged(Damage);

            }
        //}
    }

    private void slash() {
            WeaponCollider.enabled = true;
            Debug.Log("Yo");
        if (IsAttacking == true)
        {
            StopCoroutine(AttackLenght());
            StartCoroutine(AttackLenght());

        }
        else
        {
            StartCoroutine(AttackLenght());
        }

        //WeaponCollider.enabled = false;
    }

    public IEnumerator AttackLenght()
    {
        IsAttacking = true;
        yield return new WaitForSeconds(1f);
        WeaponCollider.enabled = false;
        IsAttacking = false;
    }

}