﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointToggler : MonoBehaviour {

		[SerializeField] private Joint joint;
		private Rigidbody connectedBody;

		private void Awake()
		{
		joint = joint ? joint : GetComponent<SpringJoint> ();
			if (joint) connectedBody = joint.connectedBody;
			else Debug.LogError("No joint found.", this);
		}

		private void OnEnable() { joint.connectedBody = connectedBody; }

		private void OnDisable()
		{
			joint.connectedBody = null;
			connectedBody.WakeUp();
		}

	void OnCollisionEnter(Collision collision){
		OnEnable ();
	}

	void OnCollisionExit (Collision collision){
		OnDisable ();
	}
}


