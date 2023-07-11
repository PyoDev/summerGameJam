using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mainbubble : MonoBehaviour
{
    Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Max_Y")
        {
        }
        if(collision.tag == "Player")
        {
            Destroy(this.gameObject);
            Debug.Log("dd");
        }
    }
    

}
