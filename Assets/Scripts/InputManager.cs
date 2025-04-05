using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    GameObject cursorObject;
    [SerializeField] private GameObject plateObject;
    Vector3 mousePosInScene;
    public float plateSpeed = 5f;
    public float plateAcceleration = 5f;
    Vector3 prevVelocity;

    [SerializeField] float maxMouseVelocity = 60f;
    [SerializeField] float mouseVelocityScale = 1f;
    [SerializeField] float screenDistance = 5f;

    [SerializeField] float horizontalClamp = 20f;
    [SerializeField] float verticalClamp = 20f;
    [SerializeField] float verticalCenter = .6f;

    Vector2 mousePos2D = Vector2.zero;


    void Start()
    {
        cursorObject = GameObject.Find("CursorObject");

        if (plateObject == null)
        {
            Debug.LogError("You forgot to assign the plate object on the input manager script.");
        }

        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Update()
    {
        // Update mouse position
        Vector2 mouseDelta = Vector2.ClampMagnitude(Mouse.current.delta.value * mouseVelocityScale, maxMouseVelocity * Time.deltaTime);
        mousePos2D += mouseDelta * .001f;

        float w = Screen.width;
        float h = Screen.height;

        // Clamp mouse position
        mousePos2D.x = Mathf.Clamp(mousePos2D.x, .5f - horizontalClamp, .5f + horizontalClamp);
        mousePos2D.y = Mathf.Clamp(mousePos2D.y, verticalCenter - verticalClamp, verticalCenter + verticalClamp);

        // Normalize view coordinates

        Vector2 screenPosition = new Vector2(mousePos2D.x, mousePos2D.y);

        // Invert y coordinate
        screenPosition.y = 1 - screenPosition.y;

        // Project cursor position into world space
        Vector3 mousePosVS = new Vector3(screenPosition.x, screenPosition.y, screenDistance);
        mousePosInScene = Camera.main.ViewportToWorldPoint(mousePosVS);
    }

    private void FixedUpdate()
    {
        Vector3 currentPos = cursorObject.transform.position;
        Vector3 targetPos = mousePosInScene;
        Vector3 tmpTarget = Vector3.Lerp(currentPos, targetPos, Mathf.Clamp01(plateSpeed * Time.fixedDeltaTime));
        Vector3 tmpVelocity = (tmpTarget - currentPos) / Time.fixedDeltaTime;

        prevVelocity = Vector3.Lerp(prevVelocity, tmpVelocity, Mathf.Clamp01(plateAcceleration * Time.fixedDeltaTime));

        currentPos += prevVelocity * Time.fixedDeltaTime;

        cursorObject.transform.position = currentPos;

        plateObject.transform.rotation = Quaternion.Euler(90f, 0f, 0f) * Quaternion.LookRotation(cursorObject.transform.position - plateObject.transform.position, Vector3.up);
    }
}
