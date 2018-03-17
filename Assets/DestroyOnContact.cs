using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnContact : MonoBehaviour {

    public bool isWaxable = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "WaxingStrip")
        {
            if (isWaxable == true)
            {
                Destroy(gameObject);
            } 
        }
    }
}
