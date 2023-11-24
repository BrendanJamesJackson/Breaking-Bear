using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int lives = 3;
    private int fluff_value = 50;

    public GameObject player;

    private GameObject latest_checkpoint;

    public Movement move;

    private bool faking = false;
    public float faking_time;
    private float faking_interval;
    
    public void BeenSeen()
    {
        //Debug.Log("seen");
        
        if (!faking)
        {
            if (lives == 0)
            {
                //Show game over scene
            }
            else
            {
                lives -= 1;
                player.SetActive(false);
                player.transform.position = latest_checkpoint.transform.position;
                player.SetActive(true);
            }
        }
    }

    public void SetLatestCheckpoint(GameObject cp)
    {
        latest_checkpoint = cp;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("shake");
            ShakeFluff();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            faking = true;
            faking_interval = faking_time;
        }
    }

    void CheckFakeTime()
    {
        faking_interval -= Time.deltaTime;
        if (faking_interval >= 0)
        {
            faking = false;
        }
    }
    
    void ShakeFluff()
    {
        fluff_value -= 5;
        Debug.Log(fluff_value);
        if (fluff_value <= 25)
        {
            move.SetStuffing(-1);
            player.transform.localScale = Vector3.Lerp(player.transform.localScale,new Vector3(.7f, .7f, .7f),.5f);

        }
        else if (fluff_value < 75)
        {
            move.SetStuffing(0);
            player.transform.localScale = Vector3.Lerp(player.transform.localScale,new Vector3(1f, 1f, 1f),.5f);

        }
        
    }

    public void GetFluff()
    {
        fluff_value += 5;
        Debug.Log(fluff_value);
        if (fluff_value >= 75)
        {
            move.SetStuffing(1);
            player.transform.localScale = Vector3.Lerp(player.transform.localScale,new Vector3(1.4f, 1.4f, 1.4f),.5f);
        }
        else if (fluff_value > 25)
        {
            move.SetStuffing(0);
            player.transform.localScale = Vector3.Lerp(player.transform.localScale,new Vector3(1f, 1f, 1f),.5f);
        }
    }
}
