using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.VisualScripting.Dependencies.Sqlite.SQLite3;

public class Popcat_move : MonoBehaviour
{
    [SerializeField] GameObject SideMax;
    [SerializeField] GameObject bubble;
    [SerializeField] GameObject Round_col;
    bool jj;
    public Vector2 range;
    public LayerMask layer;
    public static bool LR;
    public bool Jump;
    new SpriteRenderer renderer;
    Animator animator;
    Rigidbody2D rb;
    public float speed;
    public float JumpPoewr;
    public float interval;
    float time = 0.0f;
    float jumptime = 0.0f;
    void Start()
    {
        jj = false;
        rb = GetComponent<Rigidbody2D>();
        renderer = rb.GetComponent<SpriteRenderer>();
        Jump = false;
        animator = rb.GetComponent<Animator>();
        LR = false;
        time = 0.0f;
        jumptime = 0.0f;
    }
    void Update()
    {
        IsOnGround();
        JJump();
        Shoot();
        Down();
        Move();
    }
    public void Popani()
    {
        animator.SetBool("Pop", false);
    }
    void JJump()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            if(Jump == false)
            {
                rb.AddForce(Vector3.up * JumpPoewr, ForceMode2D.Impulse);
                jj = true;
                Jump = true;
            }
        }
    }
    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("Pop", true);
            if (LR)
            {
                Vector3 spawnPos = new Vector3(transform.position.x - interval, transform.position.y, transform.position.z);
                Instantiate(bubble, spawnPos, Quaternion.identity);
            }
            if (!LR)
            {
                Vector3 spawnPos = new Vector3(transform.position.x + interval, transform.position.y, transform.position.z);
                Instantiate(bubble, spawnPos, Quaternion.identity);
            }
        }
        if (Input.GetKey(KeyCode.Space))
        {
            time += Time.deltaTime;
            if (time > 0.5f)
            {
                animator.SetBool("Pop", true);
                if (LR)
                {
                    Vector3 spawnPos = new Vector3(transform.position.x - interval, transform.position.y, transform.position.z);
                    Instantiate(bubble, spawnPos, Quaternion.identity);

                }
                if (!LR)
                {
                    Vector3 spawnPos = new Vector3(transform.position.x + interval, transform.position.y, transform.position.z);
                    Instantiate(bubble, spawnPos, Quaternion.identity);
                }
                time = 0.0f;
            }
        }
        if (!Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("Pop", false);
        }
    }
    void Down()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Round_col.SetActive(true);
            Destroy(Instantiate(Round_col, transform.position, Quaternion.identity), 0.3f);
        }
    }
    void Move()
    {
        SideMax.transform.position = new Vector2(this.transform.position.x, 0);
        float x = Input.GetAxis("Horizontal") * speed;
        if (x < 0)
        {
            LR = true;
            renderer.flipX = true;
        }
        else if (x > 0)
        {
            LR = false;
            renderer.flipX = false;
        }
        rb.velocity = new Vector3(x * Time.deltaTime, rb.velocity.y, 0);

        this.gameObject.transform.position += new Vector3(x, 0, 0) * Time.deltaTime;
    }
    private void IsOnGround()
    {
        if(jj)
        {
            jumptime += Time.deltaTime;
            if(jumptime > 0.1f)
            {
                jumptime = 0;
                jj = false;
            }
        }
        Vector3 raypos = new Vector3(rb.position.x, rb.position.y - 0.4f, 0);
        Debug.DrawRay(raypos, new Vector3(0, -0.2f, 0), new Color(0, 1, 0));
        RaycastHit2D raycastHit = Physics2D.Raycast(raypos, new Vector2(0, -0.2f),0.5f);
        if(raycastHit.collider != null)
        {
            if(raycastHit.transform.gameObject.tag == "Wall" || raycastHit.transform.gameObject.tag == "Round")
            {
                if(!jj)
                    Jump = false;
            }
        }
    }
}