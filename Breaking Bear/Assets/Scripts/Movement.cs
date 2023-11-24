using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float base_speed;
    public float empty_modifier;
    public float stuffed_modifier;

    public bool nonstuffed;
    public bool stuffed;
    public bool midway;

    private float current_speed;

    private Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Debug.Log(rb);
        midway = true;
    }

    // Update is called once per frame
    void Update()
    {
        CalcSpeed();
        Move();
    }

    void Move()
    {
        if ((Input.GetAxis("Horizontal") != 0) || Input.GetAxis("Vertical") != 0)
        {
            //rb.AddForce(new Vector2(Input.GetAxis("Horizontal") * current_speed,0f), ForceMode2D.Impulse);
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * current_speed, Input.GetAxis("Vertical") * current_speed);
        }
        /*if (Input.GetAxis("Vertical") != 0)
        {
            //rb.AddForce(new Vector2(0f,Input.GetAxis("Vertical") * current_speed), ForceMode2D.Impulse);
            rb.velocity = new Vector2(0f,Input.GetAxis("Vertical") * current_speed);

        }*/
        if (Input.GetAxis("Horizontal") == 0)
        {
            rb.velocity = Vector2.Lerp(rb.velocity, new Vector2(0f, rb.velocity.y), Time.deltaTime);
        }
        if (Input.GetAxis("Vertical") == 0)
        {
            rb.velocity = Vector2.Lerp(rb.velocity, new Vector2(rb.velocity.x,0f), Time.deltaTime);

        }
    }

    public void SetStuffing(int stuff_value)
    {
        if (stuff_value == -1)
        {
            nonstuffed = true;
            midway = false;
            stuffed = false;
        }
        if (stuff_value == 0)
        {
            nonstuffed = false;
            midway = true;
            stuffed = false;
        }
        if (stuff_value == 1)
        {
            nonstuffed = false;
            midway = false;
            stuffed = true;
        }
    }

   
    void CalcSpeed()
    {
        if (midway)
        {
            current_speed = base_speed;
        }
        else if (nonstuffed)
        {
            current_speed = base_speed * empty_modifier;
        }
        else if (stuffed)
        {
            current_speed = base_speed * stuffed_modifier;
        }
    }
}
