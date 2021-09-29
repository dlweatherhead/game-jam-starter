using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class AddConstantVelocity : MonoBehaviour
{
    [SerializeField] private Vector3 force;
    [SerializeField] private KeyCode keyPositive;
    [SerializeField] private KeyCode keyNegative;

    private new Rigidbody rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if(Input.GetKey(keyPositive))
        {
            rigidbody.velocity += force;
        }

        if(Input.GetKey(keyNegative))
        {
            rigidbody.velocity -= force;
        }
    }
}
