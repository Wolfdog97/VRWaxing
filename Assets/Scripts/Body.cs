using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour {

    public bool isWaxable = false;
    public Material waxableMaterial;
    GameObject wStick;

    private void Start()
    {
        wStick = GameObject.FindGameObjectWithTag("WaxStick");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == wStick){

            GetComponent<Renderer>().material = waxableMaterial;
            isWaxable = true;

        }
    }


}
