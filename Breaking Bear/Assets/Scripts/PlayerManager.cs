using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject GM;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Seen()
    {
        GM.GetComponent<GameManager>().BeenSeen();
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Teddy")
        {
            col.GetComponent<DumbTeddyScript>().SetFollowTrue(this.gameObject);
        }

        if (col.tag == "Checkpoint")
        {
            GM.GetComponent<GameManager>().SetLatestCheckpoint(col.gameObject);
        }

        if (col.tag == "Fluff")
        {
            GM.GetComponent<GameManager>().GetFluff();
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            if (other.gameObject.GetComponent<Enemy>().GetLookStatus())
            {
                Seen();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Teddy")
        {
            col.GetComponent<DumbTeddyScript>().SetFollowFalse();
        }    }
}
