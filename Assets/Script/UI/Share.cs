using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeDuration = 0.2f; // 抖动持续时间  
    public float shakeMagnitude = 0.1f; // 抖动幅度  

    private Vector3 originalPosition;
    private float shakeEndTime;

    private void Start()
    {
        originalPosition = Camera.main.transform.position;
    }

    public void DoShake()
    {
        if (Time.time > shakeEndTime)
        {
            shakeEndTime = Time.time + shakeDuration;
            StartCoroutine(ShakeCamera());
        }
    }

    private IEnumerator ShakeCamera()
    {
        float elapsed = 0f;
        Vector3 shakeVector = Vector3.zero;

        while (elapsed < shakeDuration)
        {
            // 生成一个随机的抖动向量  
            shakeVector = new Vector3(Random.Range(-shakeMagnitude, shakeMagnitude),
                                     Random.Range(-shakeMagnitude, shakeMagnitude),
                                     0f);

            // 将抖动向量应用到Camera的position上  
            Camera.main.transform.position = originalPosition + shakeVector;

            // 等待一小段时间后继续下一次抖动  
            yield return new WaitForSeconds(0.01f);
            elapsed += 0.01f;
        }

        // 抖动结束后将Camera位置重置为原始位置  
        Camera.main.transform.position = originalPosition;
    }
}