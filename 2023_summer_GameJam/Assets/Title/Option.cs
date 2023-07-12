using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Option : MonoBehaviour
{
    public GameObject popupPrefab;
    public GameObject Panel;
    public GameObject X;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !popupPrefab.activeSelf)
        {
            ShowPopup();
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && popupPrefab.activeSelf)
        {
            DisablePopup();
        }
    }
    public void ShowPopup() //팝업 활성화 함수
    {
        popupPrefab.SetActive(true);
        Panel.SetActive(true);
        X.SetActive(true);
    }

    public void DisablePopup() //팝업 비활성화 함수
    {
        popupPrefab.SetActive(false);
        Panel.SetActive(false);
        X.SetActive(false);
    }
}

