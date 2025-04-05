using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerWalk : MonoBehaviour
{
    public float stepSize = 10.0f;
    public float stepTime = 1.0f;
    public AnimationCurve curve;
    
    public bool isWalking = false;
    Vector3 startPoint; 
    Vector3 targetPoint;
    float time;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        time = stepTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isWalking)
        {
            //Debug.Log("Step");
            isWalking = true;
            time = 0;
            startPoint = gameObject.transform.position;
            targetPoint = gameObject.transform.position + gameObject.transform.forward * stepSize;
        }

        if (isWalking)
        {
            Vector3 newPosition = Vector3.Lerp(startPoint, targetPoint, curve.Evaluate(time / stepTime));
            gameObject.transform.position = newPosition;
            time += Time.deltaTime;
            isWalking = time < stepTime;
        }
    }
}
