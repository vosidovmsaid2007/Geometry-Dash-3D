using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Vector3 vel = rb.velocity;
        // vel.x = 5;
        // rb.velocity = vel;

        if(Physics.Raycast(transform.position, Vector3.down, GetComponent<BoxCollider>().size.y / 2 + 0.4f))
        {
            Quaternion rot = transform.rotation;
            rot.z = Mathf.Round(rot.z / 90) * 90;
            transform.rotation = rot;

            if(Input.GetMouseButtonDown(0))
            {
                rb.velocity = Vector3.zero;
                rb.AddForce(Vector2.up * 55000);
            }
            else{
                transform.Rotate(Vector3.back * 5f);
            }
        }
    }
}
