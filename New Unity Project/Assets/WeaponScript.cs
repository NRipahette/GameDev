using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public float Damage = 7;
    private CapsuleCollider WeaponCollider;
    private Animator myAnim;
    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision.gameObject.name);
        //if (collision.transform.tag == "Enemy")
        if (myAnim.GetBool("IsAttacking") == true)
        {
            if (collision.gameObject.CompareTag("Enemy") && !collision.GetComponent<Animator>().GetBool("IsHit"))
            {
                collision.transform.GetComponent<EnemyController>().Damaged(Damage);
                collision.GetComponent<Animator>().SetBool("IsHit", true);

            }
            if (collision.gameObject.CompareTag("Player"))
            {
                Physics.IgnoreCollision(collision, WeaponCollider);
                collision.transform.GetComponent<EnemyController>().Damaged(Damage);

            }
        }
    }


}