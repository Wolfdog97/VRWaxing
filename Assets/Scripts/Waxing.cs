using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Waxing : MonoBehaviour {

    private BoxCollider stripCol;
    private Vector3 waxingPosition;
    private Quaternion waxingRotation;


    public bool canBeDetached = true;
    public GameObject hair;
    public GameObject[] hairs;

    Hand _hand;

    private void Start()
    {
        _hand = GameObject.Find("FallbackHand").GetComponent<Hand>();
        Debug.Log(_hand);

        //stripCol = GetComponent<BoxCollider>();
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("OnCollisionEnter is working");

        if (other.gameObject.GetComponent<Body>() != null)
        {
            Debug.Log("GetComponent<Body> is working");
   
            //waxingPosition = hair.transform.position;
            //waxingRotation = hair.transform.rotation;

            if (other.gameObject.GetComponent<Body>().isWaxable != false && canBeDetached != false)
            {
                _hand.DetachObject(gameObject);
                canBeDetached = false;

                //Debug.Log("waxing position: " + waxingPosition);
                //Debug.Log("waxing rotation: " + waxingRotation);

                //Debug.Log("hair transform: " + hair.transform.position);
                //Debug.Log("hair transform: " + hair.transform.rotation);

                //stripCol.enabled = !enabled;
                Debug.Log("this is working");
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (canBeDetached != true)
        {
            //stripCol.enabled = enabled;
            canBeDetached = true;
            hair.SetActive(false);

        }
    }

}
