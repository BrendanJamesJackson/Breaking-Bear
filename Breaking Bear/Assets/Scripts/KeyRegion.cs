using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyRegion : MonoBehaviour
{
    public int RequiredTeddyNum;
    private int CurrentTeddy;
    private bool PlayerOnKey;
    private bool Activated = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerOnKey)
        {
            if (CurrentTeddy == RequiredTeddyNum)
            {
                Activated = true;
            }
        }
    }

    public void AddTeddy()
    {
        CurrentTeddy += 1;
    }

    public void PlayerOn()
    {
        PlayerOnKey = true;
    }

    public void PlayerOff()
    {
        PlayerOnKey = false;
    }
}
