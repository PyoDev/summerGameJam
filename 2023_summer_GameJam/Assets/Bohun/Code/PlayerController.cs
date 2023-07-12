using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    bool isJump = false;
    bool isTop = false; //일정 높이에 도달하면 참으로 변경 후 더이상 함수가 작동하지 않게 함.
    public float jumpHeight = 0 ;  //원하는 만큼 플레이어가 점프하는 변수  
    public float jumpSpeed = 0; //점프하는 속도 변수

    Vector2 startPosition; //올라갔던 플레이어를 다시 원위치로 돌아오게함.

    Animator animator;
    void Start()
    {
        startPosition = transform.position;
        animator = GetComponent<Animator>();// animator를 가져오기    
    }

    void Update()
    {
        if(GameManage.instance.isPlay)
        {
            animator.SetBool("run", true);
        }
        else
        {
            animator.SetBool("run", false);
        }
        if(Input.GetMouseButtonDown(0) && GameManage.instance.isPlay) //마우스 버튼을 눌렀을 때 플레이어가 점프함
        {
            isJump = true;
        }
        else if(transform.position.y <= startPosition.y) //나중 위치에 오면 다시 원상복구
        {
            isJump = false;
            isTop = false;
            transform.position = startPosition;
        }
        // 점프 변수가 참일 때 플레이어가 위로 올라감
        if(isJump)
        {
            if (transform.position.y <= jumpHeight - 0.1f && !isTop) 
            {
                transform.position = Vector2.Lerp(transform.position,
                    new Vector2(transform.position.x, jumpHeight), jumpSpeed * Time.deltaTime);
            }
            else
            {
                isTop = true;
            }
            if(transform.position.y > startPosition.y && isTop) //참이고 플레이어가 스타트포지션보다 위에있을 때 플레이어를 스타트 포지션 위치로 옮겨줌
            {
                transform.position = Vector2.MoveTowards(transform.position,startPosition,jumpSpeed * Time.deltaTime);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Mob"))
        {
            GameManage.instance.GameOver();
        }
    }
}
