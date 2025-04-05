using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    GameObject cursorObject;
    [SerializeField] private GameObject plateObject;
    Vector3 mousePos;
    Vector3 mousePosInScene;
    Ray ray;
    public float plateSpeed = 5f;
    public float plateAcceleration = 5f;
    Vector3 prevVelocity;

    [SerializeField] float mouseSensitivity = 1f;

    [SerializeField] float horizontalClamp = 20f;
    [SerializeField] float verticalClamp = 20f;

    Vector2 mousePos2D = Vector2.zero;

    //public float minRoll = -70f;
    //public float maxRoll = 120f;
    //public float rollSmoothTime = 0.5f;

    //public float minPitch = 50f;
    //public float maxPitch = 70f;
    //public float pitchSmoothTime = 0.5f;
    //public float smoothTime = 0.2f;


    void Start()
    {
        cursorObject = GameObject.Find("CursorObject");
        //plateObject = GameObject.Find("Plate");
        if (plateObject == null)
        {
            Debug.LogError("You forgot to assign the plate object on the input manager script.");
        }

        Cursor.lockState = CursorLockMode.Locked;
    }

    public void OnPrimaryInput()
    {
        Debug.Log("Click");
    }

    public void OnMoveMouse(InputValue _input)
    {
        //Vector2 screenPos = _input.Get<Vector2>();
        Vector2 mouseDelta = Mouse.current.delta.value;
        //Vector2 mousePos2D = Mouse.current.position.ReadValue(); // Positions depend on resolution btw
        mousePos2D += mouseDelta;
        float w = Screen.width;
        float h = Screen.height;
        Vector2 screenCenter = new Vector2(w, h) / 2;
        mousePos = (mousePos2D - screenCenter) * mouseSensitivity + screenCenter;

        // Clamp to be within screen bounds
        //mousePos.x = Mathf.Clamp(mousePos.x, 0f, w);
        mousePos.y = /*h - mousePos.y;*/  Mathf.Clamp(h - mousePos.y, 0f, h);

        float castDistance = 5f;
        // Convert to screen space between 0 and 1
        //mousePos = new Vector3(mousePos.x, 0f/*mousePos.y*/, .5f); 
        mousePos = new Vector3(mousePos.x / w, mousePos.y / h, 5f);

        mousePosInScene = Camera.main.ViewportToWorldPoint(mousePos);
        //ray = Camera.main.ViewportPointToRay(mousePos);
        //ray = Camera.main.ScreenPointToRay(mousePos);
        //mousePosInScene = ray.GetPoint(castDistance);
        Vector3 OffsetWS = mousePosInScene - Camera.main.transform.position;
        OffsetWS.y = Mathf.Clamp(OffsetWS.y, -verticalClamp, verticalClamp);
        mousePosInScene = Camera.main.transform.position + OffsetWS;

        Vector3 offsetCamSpace = Camera.main.transform.InverseTransformPoint(mousePosInScene);
        offsetCamSpace.x = Mathf.Clamp(offsetCamSpace.x, -horizontalClamp, horizontalClamp);
        mousePosInScene = Camera.main.transform.TransformPoint(offsetCamSpace);
        //cursorObject.transform.position = Vector3.SmoothDamp(cursorObject.transform.position, mousePosInScene, ref mouseVelocity, smoothTime);
    }

    private void FixedUpdate()
    {
        Vector3 currentPos = cursorObject.transform.position;
        Vector3 targetPos = mousePosInScene;
        Vector3 tmpTarget = Vector3.Lerp(currentPos, targetPos, Mathf.Clamp01(plateSpeed * Time.deltaTime));
        Vector3 tmpVelocity = (tmpTarget - currentPos) / Time.deltaTime;

        prevVelocity = Vector3.Lerp(prevVelocity, tmpVelocity, Mathf.Clamp01( plateAcceleration * Time.deltaTime));

        currentPos += prevVelocity * Time.deltaTime;

        cursorObject.transform.position = currentPos;
        //cursorObject.transform.parent.LookAt(Vector3.down);
        /*
        prevVelocity = mouseVelocity;
        cursorObject.transform.position = Vector3.SmoothDamp(cursorObject.transform.position, mousePosInScene, ref mouseVelocity, smoothTime);
        */
        
        //plateObject.transform.LookAt(cursorObject.transform.position);
        plateObject.transform.rotation = Quaternion.Euler(90f, 0f, 0f) * Quaternion.LookRotation(cursorObject.transform.position - plateObject.transform.position, Vector3.up);
        //plateObject.transform.rotation *= Quaternion.AngleAxis(90f, plateObject.transform.right);
        //plateObject.transform.localRotation *= Quaternion.Euler(90f, 0f, 0f);

        //Quaternion targetRotation = new Quaternion();
        //float targetRoll = Mathf.Lerp(minRoll, maxRoll, mousePos.y);
        //float targetPitch = Mathf.Lerp(minPitch, maxPitch, mousePos.x);
        //currentRoll = targetRoll;
        //currentPitch = targetPitch;
        //targetRotation = Quaternion.Euler(currentPitch, 0, currentRoll);
        //plateObject.transform.rotation *= Quaternion.Euler(90f, 0f, 0f);
        //Quaternion.Slerp(plateObject.transform.rotation, targetRotation, )
        //targetRotation = DampSlerp(plateObject.transform.rotation, Quaternion.Euler(currentPitch, 0, currentRoll), 0.5f);
        //targetRotation = CustomDampSlerp(targetRotation, targetRotation);
        //targetRotation = CustomDampSlerp(targetRotation, targetRotation);
        //plateObject.transform.rotation = Quaternion.Slerp()
        //Debug.Log(Mathf.Clamp01(speed * Time.deltaTime));
        //plateObject.transform.rotation = targetRotation;// * Quaternion.Euler(90f, 0f, 0f);
    }
}
