using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpcheck : MonoBehaviour
{
    Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Debug.DrawRay(rb.position, Vector3.down, new Color(0, 0.4f, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(rb.position, Vector3.down, 0.4f, LayerMask.GetMask("Platform"));
        if (rayHit.collider != null)
        {
            Debug.Log("dd");
            if (rayHit.distance < 0.2f)
            {
                Popcat_move.Jump = false;
            }
        }
    }
}
