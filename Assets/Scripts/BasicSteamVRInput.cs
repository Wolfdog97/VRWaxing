using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSteamVRInput : MonoBehaviour {

    // this is the basic script that lets SteamVR track an object's position/rotation
    SteamVR_TrackedObject myTrackedObject;

    // reference to the actual controller in SteamVR
    SteamVR_Controller.Device myDevice // this is a proporty, which is a var that can execute code
    {
        get {
            // tell Steam to treat the track object as a contoller
            return SteamVR_Controller.Input((int)myTrackedObject.index);
        }
        //set { }
    }

	// Use this for initialization
	void Start () {
        myTrackedObject = GetComponent<SteamVR_TrackedObject>();
	}
	
	// Update is called once per frame
	void Update () {
        if (myDevice.GetHairTrigger())
        {
            Debug.Log("user is holding down the trigger");
        }

        // is the user holding down X button, on this controller?
        if (myDevice.GetPress(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad))
        {
            Debug.Log("user is holding down touchpad");
        }
	}
}
