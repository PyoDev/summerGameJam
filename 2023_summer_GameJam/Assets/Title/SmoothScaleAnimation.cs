using UnityEngine;

public class SmoothScaleAnimation : MonoBehaviour
{
    public Vector3 targetScale = new Vector3(2f, 2f, 2f); // 목표 스케일
    public float scaleSpeed = 1f; // 스케일 변경 속도

    private Vector3 originalScale;
    private bool isScalingUp = true;

    private void Start()
    {
        originalScale = transform.localScale;
    }

    private void Update()
    {
        // 부드럽게 스케일 변경
        float scaleStep = scaleSpeed * Time.deltaTime;
        if (isScalingUp)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, targetScale, scaleStep);
        }
        else
        {
            transform.localScale = Vector3.Lerp(transform.localScale, originalScale, scaleStep);
        }

        // 스케일이 목표에 도달했을 때 방향 변경
        if (Vector3.Distance(transform.localScale, targetScale) < 0.01f)
        {
            isScalingUp = false;
        }
        else if (Vector3.Distance(transform.localScale, originalScale) < 0.01f)
        {
            isScalingUp = true;
        }
    }
}