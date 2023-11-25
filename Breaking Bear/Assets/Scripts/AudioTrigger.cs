using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    private AudioSource sound;
    private CircleCollider2D col;

    private void Awake()
    {
        sound = GetComponent<AudioSource>();
        col = GetComponent<CircleCollider2D>();
    }

    public void Triggered()
    {
        sound.Play();
        Destroy(col);
    }
}
