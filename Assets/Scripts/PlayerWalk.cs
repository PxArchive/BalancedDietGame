using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PlayerWalk : MonoBehaviour
{
    public float stepSize = 10.0f;
    public float stepTime = 1.0f;
    public float shakeDelayFactor = 1f;
    public AnimationCurve curve;
    
    public bool isWalking = false;

    public UnityEvent OnShake;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isWalking)
        {
            //Debug.Log("Step");
            StartCoroutine(WalkCoroutine());
            StartCoroutine(ShakeTray());
        }
    }

    IEnumerator WalkCoroutine()
    {
        isWalking = true;
        float time = 0;
        Vector3 startPoint = gameObject.transform.position;
        Vector3 targetPoint = gameObject.transform.position + gameObject.transform.forward * stepSize;


        while (isWalking)
        {
            Vector3 newPosition = Vector3.Lerp(startPoint, targetPoint, curve.Evaluate(time / stepTime));
            gameObject.transform.position = newPosition;
            time += Time.deltaTime;
            isWalking = time < stepTime;
            yield return null;
        }
    }

    IEnumerator ShakeTray()
    {
        yield return new WaitForSeconds(shakeDelayFactor * stepTime);
        OnShake.Invoke();
    }
}
