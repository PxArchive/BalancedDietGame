using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class ExplodeOnCollision : MonoBehaviour
{
    [SerializeField] GameObject ParticleExplosion;
    public UnityEvent OnDestruction;

    private void OnCollisionEnter(Collision collision)
    {
        if (!(collision.collider.gameObject.CompareTag("Plate")
            || collision.collider.gameObject.CompareTag("FoodObject")))
        {
            OnTriggerDestruction();
        }
    }
    
    void OnTriggerDestruction()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        OnDestruction.Invoke();
        Debug.Log(transform.position);
        Instantiate(ParticleExplosion, rb.position, rb.rotation);
        Destroy(gameObject);
    }

}
