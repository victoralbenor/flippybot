using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public float jumpSpeed = 2f;
    public UnityEvent onJump;
    public UnityEvent onCollide;
    
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        Time.timeScale = 0f;
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            _rigidbody.velocity = Vector2.up * jumpSpeed;
            onJump.Invoke();
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        onCollide.Invoke();
    }
}