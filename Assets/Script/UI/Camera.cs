using UnityEngine;

public class ConstantCameraShake : MonoBehaviour
{
    // 抖动参数  
    public float shakeAmount = 0.05f; // 抖动幅度  
    public float shakeFrequency = 5f; // 抖动频率  

    private Vector3 originalPosition; // 保存摄像机的原始位置  

    void Start()
    {
        // 保存摄像机的原始位置  
        originalPosition = transform.position;
    }

    void Update()
    {
        // 计算X和Y轴上的随机偏移  
        float offsetX = Mathf.Sin(Time.time * shakeFrequency) * shakeAmount;
        float offsetY = Mathf.Sin(Time.time * shakeFrequency * 1.1f) * shakeAmount; // 稍微错位的频率以获得不规则抖动  

        // 将偏移应用到摄像机的位置  
        transform.position = new Vector3(originalPosition.x + offsetX, originalPosition.y + offsetY, originalPosition.z);

        // 如果你还想在Z轴或旋转上添加抖动，可以相应地扩展上面的代码  
    }
}