using UnityEngine;

public class SnoreAnimation : MonoBehaviour
{
    float deltaTimer = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        deltaTimer += Time.deltaTime;
        transform.rotation = Quaternion.Euler(Mathf.Lerp(45f, 95f, SinePulse(0.2f)), transform.rotation.y, transform.rotation.z);
    }

    private float SinePulse(float _pulseFrequency)
    {
        return Mathf.Clamp01(0.5f * (1f + Mathf.Sin(2f * Mathf.PI * _pulseFrequency * deltaTimer)));
    }
}
