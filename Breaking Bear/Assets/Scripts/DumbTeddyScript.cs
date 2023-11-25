using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DumbTeddyScript : MonoBehaviour
{
    private bool following = false;
    private bool on_key = false;
    private GameObject player_go;

    public float bear_speed;

    private Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        follow();
    }

    void follow()
    {
        if (following && !on_key)
        {
            transform.position = Vector3.Lerp(transform.position, player_go.transform.position, Time.deltaTime*bear_speed);
            rb.MovePosition(player_go.transform.position);
            //Debug.Log(player_go.transform.position);
        }
    }

    public void SetFollowTrue(GameObject player)
    {
        player_go = player;
        following = true;
    }

    public void SetFollowFalse()
    {
        following = false;
    }

    public void SetOnKey()
    {
            on_key = true;
        
    }
    
    
}
