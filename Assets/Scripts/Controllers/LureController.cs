using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LureController : MonoBehaviour
{
    public float speed = 5f;
    public float terminalVelocity = -1f;
    public Rigidbody2D lureRigidBody;

    void start(){
        //lureRigidBody = GetComponent<Rigidbody2D>();
        
    }
    void Update()
    {
        
    }

    void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0);

        transform.position = transform.position + movement * speed * Time.deltaTime;
        if (lureRigidBody.velocity.y < terminalVelocity) {
            lureRigidBody.velocity = new Vector2(lureRigidBody.velocity.x, terminalVelocity);
        }
    }
}