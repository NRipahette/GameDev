using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell1 : MonoBehaviour
{
    internal int SpellID = 1;

    float Base_Damage = 12;

    PlayerMovement myPlayer;

    public GameObject Effect;

    public GameObject myCamera;
    private CameraCollision my_camera;

    private SpellDatabase TheSpellDatabase;
    private InventoryManager PlayerInventory;
    public bool IsOnCooldown = false;

    private Transform CastingPoint;

    public void Start()
    {
        //GameObject.FindGameObjectWithTag("MainCamera").TryGetComponent<CameraCollision>( out my_camera);
        //myCamera = GameObject.FindGameObjectWithTag("MainCamera");
        myPlayer = FindObjectOfType<PlayerMovement>();
        TheSpellDatabase = FindObjectOfType<SpellDatabase>();
        PlayerInventory = FindObjectOfType<InventoryManager>();
        //EffectTtransform = myPlayer.transform;

    }
    public void TriggerEffect()
    {
        //if (IsOnCooldown == false)
        //{
            myCamera = GameObject.FindGameObjectWithTag("MainCamera");
            myPlayer = FindObjectOfType<PlayerMovement>();
            CastingPoint = myPlayer.transform;
            Instantiate(/*TheSpellDatabase.GetEffect(PlayerInventory.equipped)*/FindObjectOfType<EffectList>().GetEffect(), new Vector3(CastingPoint.position.x, CastingPoint.position.y + 1.5f, CastingPoint.position.z) + myCamera.transform.forward, Quaternion.LookRotation(myCamera.transform.forward)/* Quaternion.LookRotation(new Vector3(hit.point.x, hit.point.y, hit.point.z) - new Vector3(CastingPoint.position.x, CastingPoint.position.y + 1.5f, CastingPoint.position.z))*/);
            IsOnCooldown = true;
            
            StartCoroutine(Cooldown(PlayerInventory.equipped));
        //}

 
    }

    public IEnumerator Cooldown(int spellId)
    {
        yield return new WaitForSeconds(TheSpellDatabase.SpellList[spellId].cooldown);
        IsOnCooldown = false;
    }

    public void EnemyHit(Collider Enemy, int SpellId)
    {
        Enemy.transform.GetComponent<EnemyController>().Damage(TheSpellDatabase.GetDamage(SpellId));
    }

    //public override void GetTransform()
    //{
    //    myCamera = GameObject.FindGameObjectWithTag("MainCamera");
    //    GameObject camera = myCamera;
    //    EffectTransform = camera.transform;
    //    RaycastHit hit;
    //    Transform hittransform;
    //    myPlayer = FindObjectOfType<PlayerMovement>();
    //    EffectTransform.position = new Vector3(myPlayer.transform.position.x, myPlayer.transform.position.y +1, myPlayer.transform.position.z+2);

    //    if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit))
    //    {
    //        hittransform = hit.transform;
    //        EffectTransform.rotation = Quaternion.LookRotation(hittransform.position - myPlayer.transform.position);
    //    }else
    //    {
    //        EffectTransform.rotation = camera.transform.localRotation;

    //    }
    //}
}
