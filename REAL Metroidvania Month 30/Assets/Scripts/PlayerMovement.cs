using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 5f;
    public float JumpVelocity = 3;
    private Vector2 movement;

    //Is the player on the ground?
    public bool grounded => groundCollisions >= 1;
    public int groundCollisions;

    //Other Script References
    public FirstCollision FC;

    //The Leave Arrow
    public GameObject LeaveArrow;
    public bool CanLeave;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        LeaveArrow.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        float input = Input.GetAxisRaw("Horizontal"); //This will be a pain to program, change it to new input type
        movement.x = input * speed * Time.deltaTime;
        transform.Translate(movement);
        Jump();
        WalkOutDoors();
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && groundCollisions >= 1 && FC.CanTalk == false)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
            rb.AddForce(Vector2.up * JumpVelocity, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {

            groundCollisions++;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            groundCollisions--;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Sewer Entrance")
        {
            SceneManager.LoadScene(sceneName: "Sewers");
        }

        if (collision.gameObject.name == "Hideout Entrance")
        {
            SceneManager.LoadScene(sceneName: "Employee Hideout");
        }

        if (collision.gameObject.name == "Sewer 2 Entrance")
        {
            SceneManager.LoadScene(sceneName: "SecondSewer");
        }

        if (collision.gameObject.name == "Back To Surface")
        {
            SceneManager.LoadScene(sceneName: "SampleScene");
        }

        if (collision.gameObject.name == "Front Door")
        {
            LeaveArrow.SetActive(true);
            CanLeave = true;
        }

        if (collision.gameObject.name == "Throne Room Entrance")
        {
            SceneManager.LoadScene(sceneName: "Throne Room");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Front Door")
        {
            LeaveArrow.SetActive(false);
            CanLeave = false;
            
        }
    }

    void WalkOutDoors()
    {
        if (CanLeave && Input.GetKeyDown(KeyCode.UpArrow))
        {
            SceneManager.LoadScene(sceneName: "SampleScene");
        }
    }
}
