using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollision : MonoBehaviour {

	public float minDistance = 1.0f;
	public float maxDistance = 4.0f;
	public float smooth = 10.0f;
	Vector3 dollyDir;
	public Vector3 dollyDirAdjusted;
	public float distance;
    private Animator myAnimator;
	// Use this for initialization
	void Awake () {
        
        myAnimator = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Animator>();
        dollyDir = transform.localPosition.normalized;
		distance = transform.localPosition.magnitude;
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 desiredCameraPos = transform.parent.TransformPoint (dollyDir * maxDistance);
		RaycastHit hit;

        if (myAnimator.GetBool("IsAirborne")) { distance = maxDistance; }
        else if (Physics.Linecast (transform.parent.position, desiredCameraPos, out hit)) {
            if (hit.transform.tag == "Weapon" || hit.transform.tag == "Player") { }
            else
			distance = Mathf.Clamp ((hit.distance * 0.87f), minDistance, maxDistance);
				
				} else {
					distance = maxDistance;
				}

				transform.localPosition = Vector3.Slerp (transform.localPosition, dollyDir * distance, Time.deltaTime * smooth);
	}
}
