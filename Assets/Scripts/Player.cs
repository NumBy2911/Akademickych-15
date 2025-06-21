using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    public CharacterController Controller;
    public Transform camera;
    Animator animator;
    public float groundCheckRadius = 0.2f;
    public Vector3 groundCheckOffset;
    public LayerMask groundLayer;
    bool isGrounded;
    float ySpeed;
    public float speed = 6f;
    public float jumpSpeed = 30f;
    public float turnSmoothTime = 0.1f;
    Vector3 velocity;
    float turnSmoothVelocity;
    private bool isJumping;
    private bool isFalling;
    private bool isRunning;
    public Timer timer;
    [SerializeField]
    bool isHited = false;
    bool animationPlayed = false;
    public List<AudioClip> WalkSounds;
    public AudioSource isMoving;
    public AudioSource isJumped;
    public AudioSource isLanded;
    public AudioSource isKnocked;
    public List<AudioClip> HitSounds;
    public AudioSource isHitedSound;
    public int pos;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Controller = GetComponent<CharacterController>();
        timer = GameObject.Find("UI").GetComponent<Timer>();

    }
    void Awake()
    {
        Controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

    }
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        float moveAmount = Mathf.Clamp01(Mathf.Abs(horizontal) + Mathf.Abs(vertical));
        Vector3 direction = Vector3.zero;

        //if (moveAmount > 0)
        //{
        //    isMoving.enabled = true;
        //}
        //else
        //{
        //    isMoving.enabled = false;
        //}

        if (Input.GetKeyDown(KeyCode.R))
        {
            // Naèítanie aktuálnej scény (levelu)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        animationPlayed = isHited || animator.GetCurrentAnimatorStateInfo(0).IsName("Falling Down") || animator.GetCurrentAnimatorStateInfo(0).IsName("Getting Up");
        if (animationPlayed)
        {
            if (isHited && animator.GetCurrentAnimatorStateInfo(0).IsName("Getting Up"))
            {
                isHited = false;
                animator.SetBool("isHited", isHited);
            }
        }
        else
        {
            direction = new Vector3(horizontal, 0f, vertical).normalized;
        }



        GroundCheck();
        isJumping = false;
        isFalling = false;
        if (isGrounded && (moveAmount > 0))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = 4f;
                isRunning = true;
            }
            else
            {
                speed = 6f;
                isRunning = false;
            }
            if (Input.GetButtonDown("Jump") && !animationPlayed)
            {
                ySpeed = jumpSpeed;
                isJumping = true;
            }
        }
        else
        {
            speed = 6f;
            ySpeed += Physics.gravity.y * Time.deltaTime;
            isFalling = true;
        }

        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camera.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

        Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward * direction.magnitude;
        velocity = moveDirection * speed;
        velocity.y = ySpeed;

        if (direction.magnitude >= 0.1f)
        {
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

        }

        Controller.Move(velocity * Time.deltaTime);
        animator.SetFloat("moveAmount", moveAmount, 0.2f, Time.deltaTime);
        animator.SetBool("isJumping", isJumping);
        animator.SetBool("isFalling", isFalling);
        animator.SetBool("isGrounded", isGrounded);
        animator.SetBool("isRunning", isRunning);
    }

    void GroundCheck()
    {
        isGrounded = Physics.CheckSphere(transform.TransformPoint(groundCheckOffset), groundCheckRadius, groundLayer);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0, 1, 0, 0.5f);
        Gizmos.DrawSphere(transform.TransformPoint(groundCheckOffset), groundCheckRadius);
    }

    private void OnTriggerEnter(Collider hit)
    {
        Debug.Log(hit.transform.name);
        if (hit.transform.tag == "Obstacles")
        {
            if (!animationPlayed)
            {
                Debug.Log("hited");
                isHited = true;
                animator.SetBool("isHited", isHited);
            }
            hit.transform.GetComponent<AIcontroller>().Collision();

            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }

        if (hit.transform.tag == "Finish")
        {
            float time = GameObject.Find("Timer").GetComponent<Timer>().currentTime;
            GameObject.Find("Management Object").GetComponent<ManagementParameters>().setFinishedTime(time);
            SceneManager.LoadSceneAsync(2);
        }

        if (hit.transform.tag == "Car")
        {
            // Load the Death Scene
            // SceneManager.LoadScene("Death Screen");
            SceneManager.LoadSceneAsync(3);
        }
    }

    public void playWalking()
    {
        pos = (int)Mathf.Floor(Random.Range(0, WalkSounds.Count));
        isMoving.PlayOneShot(WalkSounds[pos]);
    }

    public void playJump()
    {
        isJumped.Play();
    }

    public void playLand()
    {
        isLanded.Play();
    }

    public void playKnock()
    {
        isKnocked.Play();
    }

    public void playHit()
    {
        pos = (int)Mathf.Floor(Random.Range(0, HitSounds.Count));
        isHitedSound.PlayOneShot(HitSounds[pos]);
    }
}




