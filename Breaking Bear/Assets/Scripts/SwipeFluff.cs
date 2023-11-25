using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeFluff : MonoBehaviour
{
    private GameObject selectedObject;

    public float ForceAmount;

    private float countdown = 5f;

    private bool clicked = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouseposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("click");
            Collider2D targetObject = Physics2D.OverlapPoint(mouseposition);
            if (targetObject && (targetObject.transform.gameObject == this.gameObject))
            {
                selectedObject = targetObject.transform.gameObject;
                Debug.Log("found object");
            }
        }

        if (Input.GetMouseButtonUp(0) && selectedObject)
        {
            selectedObject = null;
            Debug.Log("lose object");
        }

        if (selectedObject)
        {
            selectedObject.GetComponent<Rigidbody2D>().velocity = (mouseposition - selectedObject.transform.position) * (Time.deltaTime * ForceAmount);
            clicked = true;
        }

        if (countdown <= 0)
        {
            Destroy(this.gameObject);
        }
        else if (countdown > 0 && clicked)
        {
            countdown -= Time.deltaTime;
        }
    }
}
