using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEditor;
using Unity.VisualScripting;

public class GameManage : MonoBehaviour
{
    //½Ì±ÛÅæ ¸¸µé±â
    #region instance
    public static GameManage instance;
    public void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    #endregion
    public float timeScale;
    public delegate void OnPlay(bool isPlay);
    public OnPlay onPlay;
    public float gameSpeed = 1;
    public bool isPlay = false;
    public GameObject playBtn;

    public int score = 0;
    public TextMeshProUGUI scoreTxt;
    public Text bestscoreTxt;

    private void Start()
    {
        PlayerPrefs.SetInt("BestScore", 0);
        bestscoreTxt.text = PlayerPrefs.GetInt("BestScore").ToString();
    }
    public void Update()
    {
        Debug.Log(score);
        if (score >= 500)
        {
            SceneManager.LoadScene("Game");
        }
    }
    IEnumerator AddScore()
    {
        while (isPlay)
        {
            Debug.Log("adg");
            score++;
            scoreTxt.text = score.ToString();
            gameSpeed += 0.01f;
            yield return new WaitForSeconds(0.1f);
        }

    }

    public void PlayBtn()
    {
        Debug.Log("gre");
        playBtn.SetActive(false);
        isPlay = true;
        onPlay.Invoke(isPlay);      
        score = 0;
        scoreTxt.text = score.ToString();
        StartCoroutine(AddScore());
    }

    public void GameOver()
    {
        playBtn.SetActive(true);
        isPlay = false;
        onPlay.Invoke(isPlay);
        StopCoroutine(AddScore());
        if (PlayerPrefs.GetInt("BestScore", 0) < score)
        {
            PlayerPrefs.SetInt("BestScore", score);
            bestscoreTxt.text = score.ToString();
        }
    }
  }

