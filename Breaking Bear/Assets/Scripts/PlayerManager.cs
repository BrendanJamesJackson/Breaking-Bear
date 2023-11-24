using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Teddy")
        {
            col.GetComponent<DumbTeddyScript>().SetFollowTrue(this.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Teddy")
        {
            col.GetComponent<DumbTeddyScript>().SetFollowFalse();
        }    }
}
