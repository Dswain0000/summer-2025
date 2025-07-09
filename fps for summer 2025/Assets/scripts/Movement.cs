using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    public float walkSpeed = 4f;
    public float maxVelocityChange = 10f;

    private Vector2 moveInput;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
            Debug.LogError("⚠️ Rigidbody component is missing!");
    }

    void Update()
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"),
                                Input.GetAxisRaw("Vertical"));
        moveInput.Normalize();
    }

    void FixedUpdate()
    {
        if (rb == null) return;

        Vector3 currentVelocity;
#if UNITY_6000_0_OR_NEWER
        currentVelocity = rb.linearVelocity;
#else
        currentVelocity = rb.velocity;
#endif

        Vector3 velocityChange = CalculateMovement(walkSpeed, currentVelocity);
        rb.AddForce(velocityChange, ForceMode.VelocityChange);
    }

    Vector3 CalculateMovement(float speed, Vector3 currentVelocity)
    {
        Vector3 targetVelocity = new Vector3(moveInput.x, 0, moveInput.y);
        targetVelocity = transform.TransformDirection(targetVelocity) * speed;

        Debug.DrawRay(transform.position + Vector3.up, targetVelocity, Color.green);
        Debug.DrawRay(transform.position + Vector3.up * 0.5f, currentVelocity, Color.red);

        if (moveInput.magnitude > 0.5f)
        {
            Vector3 velocityChange = targetVelocity - currentVelocity;
            velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
            velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
            velocityChange.y = 0f;
            return velocityChange;
        }

        return Vector3.zero;
    }
}
