using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAI : MonoBehaviour
{
    Rigidbody2D rb;
    bool LR;
    void Start()
    {
        LR = true;
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (LR)
        {
            Vector3 raypos = new Vector3(rb.position.x - 0.7f, rb.position.y, 0);
            Debug.DrawRay(raypos, Vector3.down, new Color(1, 0, 0));
            RaycastHit2D raycastHit = Physics2D.Raycast(raypos, Vector3.down, 0.5f);
        }
    }
}
