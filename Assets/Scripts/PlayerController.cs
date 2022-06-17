using UnityEngine;
public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public DynamicJoystick joystick;
    public Animator animator;
    public float moveSpeed;
    private Transform tf;
    public static PlayerController ins;

    public bool move = false;
    private void Awake()
    {
        ins = this;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tf = transform;
    }

     void FixedUpdate()
    {
        rb.velocity = new Vector3(joystick.Horizontal * moveSpeed,rb.velocity.y,joystick.Vertical*moveSpeed);
        if(joystick.Horizontal !=0 || joystick.Vertical != 0)
        {
            move = true;
            tf.rotation = Quaternion.LookRotation(rb.velocity);
            animator.SetBool("Running", true);
           // animator.SetBool("Idle", false);
        }
        else
        {
            animator.SetBool("Running", false);
            //animator.SetBool("Idle", true);
        }
    }
}
