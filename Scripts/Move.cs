using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Move : MonoBehaviour
{
    [Header("Move values:")]
    [Tooltip("Do not make this value to heigh. " +
        "This will result in a heigh moving speed.")]
    public float speed = 0.05f; // Speed of the movement
    [Tooltip("This is the Rigidbody of the player. ")]
    [SerializeField]
    public Rigidbody2D rb; // Reference to the Rigidbody component
    [Tooltip("This is the canvas of the exitscreen. ")]
    [SerializeField]
    public GameObject canvas; // Reference to the Canvas Object
    [Tooltip("This is the text items in the exitscreen. ")]
    [SerializeField]
    public GameObject text; // Reference to the text Object

    // Start is called before the first frame update
    void Start()
    {
        // Get the Rigidbody component attached to this GameObject
        rb = GetComponent<Rigidbody2D>();
        canvas.gameObject.SetActive(false);
        if (!Debug.isDebugBuild) speed *= 2;
    }

    // Update is called at a fixed interval and is used for regular updates such as adjusting physics (rigidbody) objects.
    void Update()
    {
        Vector2 currentPos = rb.position;
        // Get input from the keyboard
        if (Input.GetKey(KeyCode.LeftArrow))
            currentPos.x -= speed;
        if (Input.GetKey(KeyCode.RightArrow))
            currentPos.x += speed;
        if (Input.GetKey(KeyCode.UpArrow))
            currentPos.y += speed;
        if (Input.GetKey(KeyCode.DownArrow))
            currentPos.y -= speed;
        rb.position = currentPos;
        //float moveVertical = Input.GetAxis("Vertical");

        // Calculate the movement vector
        // Vector2 movement = new Vector2(moveHorizontal, 0.0f); // moveVertical);

        // Apply a force to the Rigidbody that moves it in the calculated direction
        //rb.MovePosition(rb.position + movement);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Renderer>().material.color == Color.red)
        {
            string timeUnit = " seconds";
            float time = Time.timeSinceLevelLoad;
            if (Time.timeSinceLevelLoad >= 60)
            {
                timeUnit = " minutes";
                time = Time.timeSinceLevelLoad / 60;
            }
            TextMeshProUGUI mText = text.GetComponent<TextMeshProUGUI>();
            mText.text = "You found the exit in " + Mathf.Round(time * 10.0f) * 0.1f + timeUnit;
            canvas.gameObject.SetActive(true);
        }
    }
}
