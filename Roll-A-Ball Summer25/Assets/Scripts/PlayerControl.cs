using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerControl : MonoBehaviour
{
    private Rigidbody rb;
    private float movementx;
    private float movementy;
    [SerializeField] private float speed = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        // create a movement vector using x & y inputs// 
        Vector3 movement = new Vector3(movementx, 0.0f, z: movementy);
        
        rb.AddForce(force: movement * speed);
        // applies force to the rigidbody to move the player//
    }
    void OnMove(InputValue movementValue)
    {
        // store the x and y components of the movement//
        Vector2 movementVector = movementValue.Get<Vector2>();
        //convert input values into vector2 for movement is the code above//
        movementx = movementVector.x;
         movementy = movementVector.y;
    }
}
