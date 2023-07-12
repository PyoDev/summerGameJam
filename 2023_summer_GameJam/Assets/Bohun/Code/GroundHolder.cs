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
        temp = tiles[0]; //가장 뒤에 있는 타일을 검색
    }
    void Update()
    {
        if (GameManage.instance.isPlay)
        {
            //타일 포지션의 x좌표가 -5보다 작을 때 가장 뒤에 있는 타일을 1만큼 더 뒤에 보내줌 
            for (int i = 0; i < 10; i++)
            {
                if (tiles[i] != null)
                {
                    if (-5 >= tiles[i].transform.position.x)
                    {
                        for (int j = 0; j < tiles.Length; j++)
                        {
                            //현재 타일과 변수에 저장된 타일의 x좌표를 비교하며 현재타일이 변수 타일보다 x좌표가 크면 현재 타일로 초기화해줌
                            if (temp.transform.position.x < tiles[j].transform.position.x)
                                temp = tiles[j];
                        }
                        tiles[i].transform.position = new Vector2(temp.transform.position.x + 1, -1.5f);
                        SpriteRenderer spriteRenderer = tiles[i].GetComponent<SpriteRenderer>();
                        spriteRenderer.sprite = groundlmg[Random.Range(0, groundlmg.Length)];
                    }
                }
            }
            //반복문을 사용하여 타일을 좌측으로 이동되게 만들어줌
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
