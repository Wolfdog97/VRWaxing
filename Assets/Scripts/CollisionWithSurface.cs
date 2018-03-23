using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class CollisionWithSurface : MonoBehaviour {
	public bool isKinematic = true;
	public bool attachedToHand;

	// Use this for initialization
	void Start () {
		isKinematic = GetComponent<Rigidbody> ().isKinematic;
		attachedToHand = GameObject.Find ("joint4").GetComponent<InteractableExample> ().attachedToHand;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (attachedToHand);
		if (attachedToHand == true) {
			isKinematic = false;
		} else {
			isKinematic = true;
		}
	}
}
