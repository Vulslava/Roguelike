using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float leftMax, rightMax, speed;
    private Vector2 pos;
    private Rigidbody2D rigidbody;
    private Collider2D collider;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        collider = gameObject.GetComponent<Collider2D>();
        pos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePosition();
    }

    void UpdatePosition()
    {
        bool left = true;
        if (left)
        {
            rigidbody.velocity = new Vector2(-speed, rigidbody.velocity.y);
            if (rigidbody.velocity.x == leftMax)
                left = false;
        }
        else if (!left)
        {
            rigidbody.velocity = new Vector2(speed, rigidbody.velocity.y);
            if (rigidbody.velocity.x == leftMax)
                left = true;
        }
    }
}
