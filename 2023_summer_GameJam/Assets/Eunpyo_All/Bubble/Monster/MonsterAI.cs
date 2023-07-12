using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterAI : MonoBehaviour
{
    public GameObject child;
    float downTime;
    Rigidbody2D rb;
    SpriteRenderer sp;
    bool LR;
    public float speed;
    bool check;
    bool round;
    void Start()
    {
        downTime = 0.0f;
        round = true;
        check = false;
        LR = false;
        sp = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            check = true;
            Destroy(child);
        }
        if(collision.transform.gameObject.layer == 7 || collision.transform.gameObject.layer == 3)
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        if (!check)
        {
            if (LR)
            {
                rb.velocity = new Vector3(speed * Time.deltaTime * -1 * 10, rb.velocity.y, 0);
                sp.flipX = true;
            }
            else
            {
                rb.velocity = new Vector3(speed * Time.deltaTime * 10, rb.velocity.y, 0);
                sp.flipX = false;
            }
            if (LR)
            {
                int layMask = (-1) - (1 << LayerMask.NameToLayer("k"));
                Vector3 raypos = new Vector3(rb.position.x - 0.7f, rb.position.y, 0);
                Debug.DrawRay(raypos, Vector3.down, new Color(1, 0, 0));
                RaycastHit2D raycastHit = Physics2D.Raycast(raypos, Vector3.down, 0.5f, layMask);
                if (raycastHit.collider == null)
                {
                    LR = !LR;
                    Debug.Log("RR");
                }
                else if (raycastHit.collider != null)
                {
                    if (raycastHit.transform.gameObject.tag == "Wall")
                    {
                        LR = !LR;
                        Debug.Log("RR");
                    }
                }
            }
            else if (!LR)
            {
                int layMask = (-1) - (1 << LayerMask.NameToLayer("k"));
                Vector3 raypos = new Vector3(rb.position.x + 0.7f, rb.position.y, 0);
                Debug.DrawRay(raypos, Vector3.down, new Color(1, 0, 0));
                RaycastHit2D raycastHit = Physics2D.Raycast(raypos, Vector3.down, 0.5f, layMask);
                if (raycastHit.collider == null)
                {
                    LR = !LR;
                    Debug.Log("RR");
                }
                else if (raycastHit.collider != null)
                {
                    if (raycastHit.transform.gameObject.tag == "Wall")
                    {
                        LR = !LR;
                        Debug.Log("RR");
                    }
                }
            }
            if (check)
            {
                Checkbottem();
                MonsterMove();
            }
        }
        void MonsterMove()
        {
            if (LR)
            {
                int layMask = (-1) - (1 << LayerMask.NameToLayer("k"));
                Vector3 raypos = new Vector3(rb.position.x - 0.7f, rb.position.y, 0);
                Debug.DrawRay(raypos, Vector3.down, new Color(1, 0, 0));
                RaycastHit2D raycastHit = Physics2D.Raycast(raypos, Vector3.down, 0.5f, layMask);
                if (raycastHit != false && raycastHit.transform.gameObject.tag == "Wall")
                    LR = !LR;
                rb.velocity = new Vector3(speed * Time.deltaTime * -1 * 13, rb.velocity.y, 0);
                sp.flipX = true;
            }
            else
            {
                int layMask = (-1) - (1 << LayerMask.NameToLayer("k"));
                Vector3 raypos = new Vector3(rb.position.x + 0.7f, rb.position.y, 0);
                Debug.DrawRay(raypos, Vector3.down, new Color(1, 0, 0));
                RaycastHit2D raycastHit = Physics2D.Raycast(raypos, Vector3.down, 0.5f, layMask);
                if (raycastHit != false && raycastHit.transform.gameObject.tag == "Wall")
                    LR = !LR;
                rb.velocity = new Vector3(speed * Time.deltaTime * 13, rb.velocity.y, 0);
                sp.flipX = false;
            }

        }
        void Checkbottem()
        {
            if (!round)
            {
                Debug.DrawRay(transform.position, new Vector3(0, -0.2f, 0), new Color(0, 1, 0));
                RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, new Vector2(0, -0.2f), 0.5f);
                if (raycastHit.collider == null)
                {
                    downTime += Time.deltaTime;
                    if (downTime > 0.6f)
                    {
                        rb.velocity = new Vector3(0, 0, 0);
                        downTime = 0;
                    }
                }
            }
        }
    }
}
