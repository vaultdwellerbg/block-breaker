using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] AudioClip[] sounds;

    private Vector2 paddleToBallVector;
    private bool isLaunched = false;
    AudioSource audioSource;
    Rigidbody2D rigidBody;


    void Start()
    {
        paddleToBallVector = transform.position - paddle.transform.position;

        audioSource = GetComponent<AudioSource>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isLaunched) return;

        LockBallToPaddle();
        LaunchOnMouseClick();
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void LaunchOnMouseClick() 
    {
        if (Input.GetMouseButtonDown(0))
        {
            isLaunched = true;
            rigidBody.velocity = new Vector2(xPush, yPush);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isLaunched)
        {
            AudioClip randomClip = sounds[Random.Range(0, sounds.Length)];
            audioSource.PlayOneShot(randomClip);
        }
    }
}
