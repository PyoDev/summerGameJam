using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class semiconductor : MonoBehaviour
{
    GameObject child;
    private void Start()
    {
        child = transform.Find("child").gameObject;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            child.SetActive(false);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            child.SetActive(true);
        }
    }
}
