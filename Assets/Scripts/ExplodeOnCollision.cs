using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class ExplodeOnCollision : MonoBehaviour
{
    [SerializeField] GameObject ParticleExplosion;
    public UnityEvent OnDestruction;
    PlayerWalk walker;
    Rigidbody rb;

    private void Start()
    {
        walker = FindFirstObjectByType<PlayerWalk>();
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!(collision.collider.gameObject.CompareTag("Plate")
            || collision.collider.gameObject.CompareTag("FoodObject")))
        {
            OnTriggerDestruction();
        }
    }

    private void Update()
    {
        if (walker.isWalking)
        {
            rb.useGravity = false;
        }
        else
        {
            rb.useGravity = true;
        }
    }

    void OnTriggerDestruction()
    {
        OnDestruction.Invoke();
        Debug.Log("Exploded: " + transform.position);
        if (ParticleExplosion != null)
        {
            Instantiate(ParticleExplosion, rb.position, rb.rotation);
        }
        GetComponent<AudioSource>().Play();
        //Destroy(gameObject);
    }

}
