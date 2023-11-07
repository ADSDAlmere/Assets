using Unity.Android.Types;
using UnityEditor;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 0.05f; // Speed of the movement
    public Rigidbody2D rb; // Reference to the Rigidbody component
    // Start is called before the first frame update
    void Start()
    {
        // Get the Rigidbody component attached to this GameObject
        rb = GetComponent<Rigidbody2D>();
    }

    // FixedUpdate is called at a fixed interval and is used for regular updates such as adjusting physics (rigidbody) objects.
    void Update()   // Can be Update, thats called once per frame
    {
        //Vector2 movement = new Vector2(0.0f, 0.0f); ;
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
            EditorUtility.DisplayDialog("Done", "You found the exit in " + Mathf.Round(time * 10.0f) * 0.1f + timeUnit, "Done");
            Application.Quit();
        }
    }
}
