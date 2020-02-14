using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public float Damage = 7;
    private CapsuleCollider WeaponCollider;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        //if (collision.transform.tag == "Enemy")
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.transform.GetComponent<EnemyController>().Damaged(Damage);

        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Physics.IgnoreCollision(collision.collider, WeaponCollider);
            collision.transform.GetComponent<EnemyController>().Damaged(Damage);

        }
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hitTrigger");
    }

}