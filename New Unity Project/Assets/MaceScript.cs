using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaceScript : MonoBehaviour
{
    public float Damage = 7;
    private CapsuleCollider WeaponCollider;
    // Start is called before the first frame update
    void Start()
    {
        WeaponCollider = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            //collision.transform.GetComponent<EnemyController>().Damaged(Damage);
            Debug.Log("hit");
        }
    }

}
