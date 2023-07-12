using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mainbubble : MonoBehaviour
{
    public GameObject bubble_pop;
    Rigidbody2D rb;
    bool Max_Y;
    Vector2 pos;
    bool Up;
    private void Start()
    {
        Up = false;
        Max_Y = false;
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if(Max_Y)
        {
            if(Up)
            {

            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Max_Y")
        {
            Max_Y = true;
            rb.gravityScale = 0.0f;
            if (Max_Y == false)
            {
                pos = transform.position;
            }
        }
        if(collision.tag == "Player")
        {
            Instantiate(bubble_pop,transform.position,Quaternion.identity);
            Destroy(this.gameObject);
            Debug.Log("dd");
        }
    }
    

}
