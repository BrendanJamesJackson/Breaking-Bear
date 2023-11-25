using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnKeyScript : MonoBehaviour
{
    private bool on_key = false;

    private DumbTeddyScript DTS;

    public KeyRegion kr;
    
    // Start is called before the first frame update
    void Start()
    {
        DTS = GetComponentInParent<DumbTeddyScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (on_key)
        {
            DTS.SetOnKey();
            
        }
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "KeyRegion")
        {
            //Debug.Log("key test");
            on_key = true;
            kr.AddTeddy();
        }
    }
}
