
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle1;
    [SerializeField] float randomFactor = 0.2f;

    Rigidbody2D myRigidBody2D;

    Vector2 paddleToBallVector;
    bool hasStarted = false;

    void Start()
    {
        myRigidBody2D = GetComponent<Rigidbody2D>();
        paddleToBallVector = transform.position - paddle1.transform.position;
    }

    void Update()
    {
        
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
         
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            myRigidBody2D.velocity = new Vector2(10f, 15f);
            
        }
    }

    private void LockBallToPaddle()
    {  
        Vector2 paddlePosition = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePosition + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2
            (Random.Range(0f, randomFactor),
            Random.Range(0f, randomFactor));

        if (hasStarted)
        {
            GetComponent<AudioSource>().Play();
            myRigidBody2D.velocity += velocityTweak;
        }
    }
}
    