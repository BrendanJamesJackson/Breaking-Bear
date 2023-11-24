using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private bool working = true;
    private bool looking = false;

    public float working_interval;
    public float looking_duration;
    private float time_remaining;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (working)
        {
            NowWorking();
            GetComponent<SpriteRenderer>().color = Color.green;
        }
        else if (looking)
        {
            NowLooking();
            GetComponent<SpriteRenderer>().color = Color.red;

        }
    }

    void NowWorking()
    {
        if (time_remaining <= 0)
        {
            working = false;
            looking = true;
            time_remaining = looking_duration;
        }
        else
        {
            time_remaining -= Time.deltaTime;
        }
    }

    void NowLooking()
    {
        if (time_remaining <= 0)
        {
            working = true;
            looking = false;
            time_remaining = working_interval;
        }
        else
        {
            time_remaining -= Time.deltaTime;
        }
    }

    public bool GetLookStatus()
    {
        return looking;
    }
}
