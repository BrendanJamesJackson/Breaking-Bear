using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject GM;
    public GameObject Reject;
    
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

        if (col.tag == "RejectBear")
        {
            Reject.GetComponent<RejectBear>().InRange();
        }

        if (col.tag == "AudioPoint")
        {
            col.GetComponent<AudioTrigger>().Triggered();
        }

        if (col.tag == "KeyRegion")
        {
            col.GetComponent<KeyRegion>().PlayerOn();
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
        }    
        
        if (col.tag == "RejectBear")
        {
            Reject.GetComponent<RejectBear>().OutRange();
        }
        
        if (col.tag == "KeyRegion")
        {
            col.GetComponent<KeyRegion>().PlayerOff();
        }
    }
}
