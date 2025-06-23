using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class PlayerControl : MonoBehaviour
{
    private Rigidbody rb;
    private int count;
    private float movementx;
    private float movementy;
    [SerializeField] private float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    void Start()
    {
        winTextObject.SetActive(false);
        count = 0;
        rb = GetComponent<Rigidbody>();
        SetCountText();
    }
    private void FixedUpdate()
    {
        // create a movement vector using x & y inputs// 
        Vector3 movement = new Vector3(movementx, 0.0f, z: movementy);

        rb.AddForce(force: movement * speed);
        // applies force to the rigidbody to move the player//
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pickup"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();

        }

    }
    void OnMove(InputValue movementValue)
    {
        // store the x and y components of the movement//
        Vector2 movementVector = movementValue.Get<Vector2>();
        //convert input values into vector2 for movement is the code above//
        movementx = movementVector.x;
        movementy = movementVector.y;
    }
    void SetCountText()
    {
        if (count >= 15)
        {
            winTextObject.SetActive(true);
            Destroy(GameObject.FindGameObjectWithTag("enemy"));
        }


        countText.text = "Count: " + count.ToString();
    }
   private void OnCollisionEnter(Collision collision)
{
   if (collision.gameObject.CompareTag("enemy"))
   {
       // Destroy the current object
       Destroy(gameObject); 
       // Update the winText to display "You Lose!"
       winTextObject.gameObject.SetActive(true);
       winTextObject.GetComponent<TextMeshProUGUI>().text = "You Lose!";
   }
}
}
