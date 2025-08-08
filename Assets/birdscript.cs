using UnityEngine;

public class birdscript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public logicscript logic;
    public bool birdIsAlive = true;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<logicscript>();
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && birdIsAlive)
        {
            myRigidbody.velocity = Vector2.up * flapStrength;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "ScoreZone")
        {
            logic.gameOver();
            birdIsAlive = false;
            myRigidbody.velocity = Vector2.zero;
            myRigidbody.isKinematic = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" ||
            collision.gameObject.tag == "Obstacle" ||
            collision.gameObject.tag == "cloud")
        {
            logic.gameOver();
            birdIsAlive = false;
            myRigidbody.velocity = Vector2.zero;
            myRigidbody.isKinematic = true;
        }
    }
}
