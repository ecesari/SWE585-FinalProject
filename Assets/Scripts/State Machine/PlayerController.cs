using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CapsuleCollider capsuleCollider;
    private Rigidbody rb;

    public float jumpForce;
    public float superJumpForce;

    private float currentSpeed;
    public int superJumps;


    [HideInInspector]
    public float forwardInput = 0;
    [HideInInspector]
    public float horizontalInput = 0;

    [SerializeField]
    private Transform SpawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider>();
        rb = GetComponent<Rigidbody>();
        currentSpeed = 100.0f; 
        superJumps = 1;
    }

    // Update is called once per frame
    void Update()
    {
        forwardInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = SpawnPosition.position;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

    public void Move()
    {
        rb.velocity = new Vector3(horizontalInput, rb.velocity.y, 0);
    }
    public void ApplySlowdown()
    {
        StartCoroutine(CheckBhop());
    }

    //completely pointless, only used to enable bunnyhopping
    public IEnumerator CheckBhop()
    {
        yield return new WaitForSeconds(0.25f);
        if (IsGrounded() || rb.velocity.y < 0)
            currentSpeed = 100.0f;
        else
            currentSpeed = Mathf.Clamp(currentSpeed + 15f, 100.0f, 225.0f);
        yield break;
    }

    public void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        rb.AddForce(new Vector3(0, jumpForce, 0));
    }

    public void SuperJump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        rb.AddForce(new Vector3(0, superJumpForce, 0));
    }

    public void AddGravity(float force)
    {
        rb.AddForce(new Vector3(0, -force, 0));
    }

    public bool IsGrounded()
    {
        return Physics.CheckCapsule(capsuleCollider.bounds.center, new Vector3(capsuleCollider.bounds.center.x, capsuleCollider.bounds.min.y - 0.02f, capsuleCollider.bounds.center.z), 0.05f, LayerMask.GetMask("Default"));
    }

    //converts velocity vector to 2D, then gets its x, which is actually x and z velocities added together.
    public float GetVerticalVelocity()
    {
        return rb.velocity.y;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null)
        {

        }
    }

}
