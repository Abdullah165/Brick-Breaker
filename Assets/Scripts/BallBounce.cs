using UnityEngine.SceneManagement;
using UnityEngine;

public class BallBounce : Subject
{
    Rigidbody2D rigidbody2D;
    Vector2 lastVelocity;

    [SerializeField] int numberOfBlocks;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = new Vector2(5f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        lastVelocity = rigidbody2D.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            NotifiyObservers(BallActions.Drop);
            lastVelocity = Vector2.zero;
        }

        if (collision.gameObject.CompareTag("block"))
        {
            NotifiyObservers(BallActions.CollisionWithBlocks);

            numberOfBlocks--;
            if (numberOfBlocks == 0)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            if (SceneManager.GetActiveScene().buildIndex == 4 && numberOfBlocks == 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 4);
            }
        }

        var ballSpeed = lastVelocity.magnitude + 0.2f;
        var reflectOfDirection = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

        rigidbody2D.velocity = reflectOfDirection * Mathf.Max(ballSpeed, 0);
    }
}
