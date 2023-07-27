using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    

    public void Start(){
        GameObject hook = GameObject.FindGameObjectWithTag("hook");
        Physics2D.IgnoreCollision(hook.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }


    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        desiredPosition.z = -10;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        
    }
}