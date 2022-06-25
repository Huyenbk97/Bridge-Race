using UnityEngine;
public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public DynamicJoystick joystick;
    public Animator animator;
    public float moveSpeed;
    private Transform tf;
    public static PlayerController ins;
    private PlayerBrickController brickController;
    public string playerColorName="red";
    public bool move = false;
    private void Awake()
    {
        ins = this;
    }
    void Start()
    {
        brickController = GetComponent<PlayerBrickController>();
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
        }
        else
        {
            animator.SetBool("Running", false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Brick brick = other.transform.GetComponent<Brick>();
        if (brick.colorName == playerColorName)
        {
            other.gameObject.SetActive(false);
            brickController.UpdatePlayerBricks();
        }

    }
}
