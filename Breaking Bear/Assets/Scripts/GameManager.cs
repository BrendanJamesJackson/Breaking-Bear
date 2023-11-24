using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int lives = 3;

    public GameObject player;

    private GameObject latest_checkpoint;
    
    public void BeenSeen()
    {
        //Debug.Log("seen");
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
            ShakeFluff();
        }
    }

    void ShakeFluff()
    {
        
    }
}
