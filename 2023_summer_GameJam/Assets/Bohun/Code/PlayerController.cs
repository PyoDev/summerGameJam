using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    bool isJump = false;
    bool isTop = false; //���� ���̿� �����ϸ� ������ ���� �� ���̻� �Լ��� �۵����� �ʰ� ��.
    public float jumpHeight = 0 ;  //���ϴ� ��ŭ �÷��̾ �����ϴ� ����  
    public float jumpSpeed = 0; //�����ϴ� �ӵ� ����

    Vector2 startPosition; //�ö󰬴� �÷��̾ �ٽ� ����ġ�� ���ƿ�����.

    Animator animator;
    void Start()
    {
        startPosition = transform.position;
        animator = GetComponent<Animator>();// animator�� ��������    
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
        if(Input.GetMouseButtonDown(0) && GameManage.instance.isPlay) //���콺 ��ư�� ������ �� �÷��̾ ������
        {
            isJump = true;
        }
        else if(transform.position.y <= startPosition.y) //���� ��ġ�� ���� �ٽ� ���󺹱�
        {
            isJump = false;
            isTop = false;
            transform.position = startPosition;
        }
        // ���� ������ ���� �� �÷��̾ ���� �ö�
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
            if(transform.position.y > startPosition.y && isTop) //���̰� �÷��̾ ��ŸƮ�����Ǻ��� �������� �� �÷��̾ ��ŸƮ ������ ��ġ�� �Ű���
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
