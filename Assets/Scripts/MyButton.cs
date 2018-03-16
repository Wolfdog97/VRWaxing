using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Valve.VR.InteractionSystem;

    [RequireComponent(typeof(Interactable))] // forces us to have an Interactable script nex to this script
public class MyButton : MonoBehaviour {


    // fires ever frame as lond as a hand (mouse or VR controller) is next to it
    void HandHoverUpdate(Hand myHand)
    {   
        // GetStandardInteractionButton == mouse click if in fallback mode, or trigger if in VR
        if (myHand.GetStandardInteractionButtonDown())
        {
            Debug.Log("players clicked or triggerd on me!");
        }
    }
}
