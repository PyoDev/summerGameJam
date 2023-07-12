using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mob : MonoBehaviour
{
    public float mobSpeed = 0;
    public Vector2 StartPosition;

    // 오브젝트가 실행될때 활성화
    private void OnEnable()
    {
        transform.position = StartPosition; 
    }


    void Update()
    {
        if (GameManage.instance.isPlay)
        {
        transform.Translate(Vector2.left*Time.deltaTime * GameManage.instance.gameSpeed);
        }

        if(transform.position.x < -6)
        {
            gameObject.SetActive(false);
        }
    }
}
