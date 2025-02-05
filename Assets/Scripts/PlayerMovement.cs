using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f, jumpForce = 10f;
    [SerializeField] private float fallMultuplier = 2.5f, lowJumpMultiplier = 2f;

    private Rigidbody rb;
    private bool doJump = false;
    private bool isJumping = false;

    void Awake()
    {
        rb = transform.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(Input.GetButtonDown("Jump") && !isJumping){
            doJump = true;
            isJumping = false;
        }
    }

    void FixedUpdate()
    {
        Vector3 moveVect = Vector3.forward;
        moveVect = moveVect.normalized * moveSpeed * Time.deltaTime;

        rb.MovePosition(transform.position + moveVect);

        if(doJump){
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            doJump = false;
        }

        if(rb.velocity.y < 0){
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultuplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump")){
            rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    void OnCollisionEnter(Collision other){
        if(other.gameObject.CompareTag("Ground")){
            isJumping = false;
        }
    }

    
}