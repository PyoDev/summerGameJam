using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MainGame_Move : MonoBehaviour
{
    Rigidbody2D rb;
    float time;
    public float speed;
    public float JumpPoewr;
    public static bool Jump;
    private void Awake()
    {
        time = 0.0f;
        rb = GetComponent<Rigidbody2D>();
        Jump = false;
    }
    void Update()
    {
        if(Jump)
        {
            time += Time.deltaTime;
        }
        rb.velocity = new Vector2(speed,rb.velocity.y);
        this.gameObject.transform.position += new Vector3(speed,0,0) * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && Jump == false)
        {
            rb.AddForce(Vector3.up * JumpPoewr, ForceMode2D.Impulse);
            Jump = true;
        }
        int layMask = (-1) - (1 << LayerMask.NameToLayer("UI"));
        Debug.DrawRay(rb.position, new Vector3(0,-0.3f,0), new Color(0, 1, 0));
        RaycastHit2D raycastHit = Physics2D.Raycast(rb.position, new Vector3(0, -0.3f, 0), 0.6f, layMask);
        if (raycastHit.collider != null)
        {
            if(raycastHit.transform.gameObject.tag == "Round")
            {
                Debug.Log(raycastHit.transform.gameObject.tag);
                if(time > 0.3f)
                {
                    Jump = false;
                    time = 0.0f;
                }
            }
        }
    }
}
