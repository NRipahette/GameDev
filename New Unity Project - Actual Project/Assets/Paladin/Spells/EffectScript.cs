using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectScript : MonoBehaviour
{

    public Animator myAnimator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerEffect(GameObject effect,Transform effectTransform)
    {
        Instantiate(effect, effectTransform.position, effectTransform.rotation);
    }

    //public void InstanciateEffect()
    //{
    //    Instantiate(effect, effectTransform.position, effectTransform.rotation);

    //}
}
