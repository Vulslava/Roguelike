using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public int xVelocity = 5;
    public int yVelocity = 10;
    public LayerMask ground, trap, enemy, finish;
    private Rigidbody2D rigidbody;
    private Collider2D collider;
    private Vector2 positionStart;
    public string scene = "";

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        collider = gameObject.GetComponent<Collider2D>();
        positionStart = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePosition();
    }

    void UpdatePosition()
    {
        float moveInput = Input.GetAxis("Horizontal");
        float jumpInput = Input.GetAxis("Jump");
        if (moveInput < 0)
            rigidbody.velocity = new Vector2(-xVelocity, rigidbody.velocity.y);
        else if (moveInput > 0)
            rigidbody.velocity = new Vector2(xVelocity, rigidbody.velocity.y);
        else if (collider.IsTouchingLayers(ground))
            rigidbody.velocity = Vector2.zero;
        if (jumpInput > 0 && collider.IsTouchingLayers(ground))
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, yVelocity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collider.IsTouchingLayers(trap))
            rigidbody.position = positionStart;
        if (collider.IsTouchingLayers(enemy))
            Destroy(collision.gameObject);
        if (collider.IsTouchingLayers(finish))
            SceneManager.LoadScene(scene);
    }
}
