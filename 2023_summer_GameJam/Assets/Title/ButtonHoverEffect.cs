using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private TextMeshProUGUI textMeshProGUI;

    private Color originalColor; //원래 텍스트 색상
    private Color hoverColor; //마우스를 올렸을 때 바뀌는 색상
    public float hoverScale = 1.1f; // 마우스 올릴 때 크기 조정 비율
    private Vector3 originalScale; // 원래 크기
    private Vector3 targetScale; // 목표 크기


    void Start()
    {
        textMeshProGUI = GetComponent<TextMeshProUGUI>();
        originalColor = textMeshProGUI.color; //원래 텍스트 색상 설정
        hoverColor = new Color(originalColor.r, originalColor.g, originalColor.b, 0.8f); //마우스를 올렸을 때 바뀌는 색상 설정
        textMeshProGUI = GetComponent<TextMeshProUGUI>();
        originalScale = transform.localScale; //원래 크기 설정
        targetScale = originalScale * hoverScale; // 스케일을 바꿀 정도
    }

    public void OnPointerEnter(PointerEventData eventData) //마우스가 올라오면 변화
    {
        textMeshProGUI.color = hoverColor;
        LeanTween.scale(gameObject, targetScale, 0.2f);
    }

    public void OnPointerExit(PointerEventData eventData) //마우스가 내려가면 원상태 복구
    {
        textMeshProGUI.color = originalColor;
        LeanTween.scale(gameObject, originalScale, 0.2f);
    }

}