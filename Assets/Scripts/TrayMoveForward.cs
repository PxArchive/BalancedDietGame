using UnityEngine;

public class TrayMoveForward : MonoBehaviour
{
    Rigidbody rb;
    public PlayerWalk playerWalk;
    Vector3 offset;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        offset = transform.position - playerWalk.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //rb.MovePosition(playerWalk.transform.position + offset);
        transform.position = playerWalk.transform.position + offset;
    }

    void FixedUpdate()
    {
        Vector3 targetPosition = playerWalk.transform.position + offset;
        float alpha = Mathf.Clamp(20 * Time.deltaTime, 0, 1);
        //Debug.Log(alpha);
        //rb.MovePosition(Vector3.Lerp(transform.position, targetPosition, alpha));
        //rb.MovePosition(targetPosition);

    }
}
