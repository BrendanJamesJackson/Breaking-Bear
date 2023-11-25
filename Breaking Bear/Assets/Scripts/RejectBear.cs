using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RejectBear : MonoBehaviour
{
    private bool in_range;

    public GameObject player;
    
    void CheckCollected()
    {
        if (in_range && Input.GetKeyDown(KeyCode.E))
        {
            transform.SetParent(player.transform);
        }
    }

    private void Update()
    {
        CheckCollected();
    }

    public void InRange()
    {
        in_range = true;
    }

    public void OutRange()
    {
        in_range = false;
    }
}
