using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GroundHolder : MonoBehaviour
{
    public GameObject[] tiles = new GameObject[10];
    public Sprite[] groundlmg;
    public float speed;
    GameObject temp;
    void Start()
    {
        temp = tiles[0]; //���� �ڿ� �ִ� Ÿ���� �˻�
    }
    void Update()
    {
        if (GameManage.instance.isPlay)
        {
            //Ÿ�� �������� x��ǥ�� -5���� ���� �� ���� �ڿ� �ִ� Ÿ���� 1��ŭ �� �ڿ� ������ 
            for (int i = 0; i < 10; i++)
            {
                if (tiles[i] != null)
                {
                    if (-5 >= tiles[i].transform.position.x)
                    {
                        for (int j = 0; j < tiles.Length; j++)
                        {
                            //���� Ÿ�ϰ� ������ ����� Ÿ���� x��ǥ�� ���ϸ� ����Ÿ���� ���� Ÿ�Ϻ��� x��ǥ�� ũ�� ���� Ÿ�Ϸ� �ʱ�ȭ����
                            if (temp.transform.position.x < tiles[j].transform.position.x)
                                temp = tiles[j];
                        }
                        tiles[i].transform.position = new Vector2(temp.transform.position.x + 1, -1.5f);
                        SpriteRenderer spriteRenderer = tiles[i].GetComponent<SpriteRenderer>();
                        spriteRenderer.sprite = groundlmg[Random.Range(0, groundlmg.Length)];
                    }
                }
            }
            //�ݺ����� ����Ͽ� Ÿ���� �������� �̵��ǰ� �������
            for (int i = 0; i < tiles.Length; i++)
            {
                if (tiles[i] != null)
                {
                    tiles[i].transform.Translate(new Vector2(-1, 0) * Time.deltaTime * GameManage.instance.gameSpeed);
                }
            }
        }
    }
}
