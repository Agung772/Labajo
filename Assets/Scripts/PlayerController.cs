using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public bool operation = true;

    public float speedPlayer;

    public float jumpForce;
    public float turnSmoothTime;
    float turnSmoothVelocity;


    public float gravity;
    float directionY;
    public Vector3 velocity;

    [Space]
    [Space]
    public CharacterController characterController;
    public new Transform camera;
    public Transform designKarakter;
    public CheckGround checkGround;
    public Animator animator;

    [HideInInspector]
    public float speedNormal;
    private void Awake()
    {
        instance = this;

        speedNormal = speedPlayer;
    }

    IEnumerator Start()
    {
        yield return new WaitForSeconds(0.1f);
        if (operation)
        {
            operation = false;
            yield return new WaitForSeconds(0.1f);
            transform.position = GameSave.instance.posisiPlayer;
            yield return new WaitForSeconds(0.1f);
            operation = true;
        }
        else
        {
            transform.position = GameSave.instance.posisiPlayer;
        }
    }

    private void OnDisable()
    {
        GameSave.instance.SavePosisiPlayer(transform.position.x, transform.position.y, transform.position.z);
    }

    void Update()
    {
        MovePlayer();
        AnimasiPlayer();
    }

    void MovePlayer()
    {
        float horizontal = 0;
        float vertical = 0;
        if (operation)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
        }


        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0, angle, 0);


            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            characterController.Move(moveDir.normalized * speedPlayer * Time.deltaTime);

        }

        //Rotasi ngikutin camera
        designKarakter.rotation = Quaternion.Euler(0, camera.eulerAngles.y, 0);

        if (Input.GetKey(KeyCode.Space) && operation)
        {
            directionY = jumpForce;
            animator.SetTrigger("Jump");
            animator.SetBool("Unjump", false);
        }

        directionY += gravity * Time.deltaTime;
        velocity.y = directionY;
        if (checkGround.ground) directionY = -5f;

        characterController.Move(velocity * Time.deltaTime);
    }

    Vector3 directionC;
    public float angle;
    void AnimasiPlayer()
    {
        //Input move
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        float moveAnimasi = new Vector3(horizontal, 0, vertical).magnitude;


        //Calculate angle player
        Vector3 forward = transform.forward;
        forward.y = 0;

        angle = Vector3.Angle(directionC, forward);

        directionC = camera.position - transform.position;
        directionC.y = 0;



        if (moveAnimasi > 0 && operation)
        {
            animator.SetBool("Idle", false);
            animator.SetFloat("X", horizontal);
            animator.SetFloat("Z", vertical);

            animator.SetFloat("IdleX", 0);
            animator.SetFloat("IdleZ", 0);
        }

        else
        {
            animator.SetBool("Idle", true);

            animator.SetFloat("X", 0);
            animator.SetFloat("Z", 0);

            if (angle < 35f)
            {
                //print("Belakang");
                animator.SetFloat("IdleX", 0);
                animator.SetFloat("IdleZ", -1);

            }
            else if (angle < 145 && designKarakter.localEulerAngles.y < 180)
            {
                //print("Kiri");
                animator.SetFloat("IdleX", -1);
                animator.SetFloat("IdleZ", 0);
            }
            else if (angle < 145 && designKarakter.localEulerAngles.y > 180)
            {
                //print("Kanan");
                animator.SetFloat("IdleX", 1);
                animator.SetFloat("IdleZ", 0);
            }
            else if (angle < 180)
            {
                //print("Depan");
                animator.SetFloat("IdleX", 0);
                animator.SetFloat("IdleZ", 1);
            }
            else
            {
                //print("Depan");
                animator.SetFloat("IdleX", 0);
                animator.SetFloat("IdleZ", 1);
            }
            
        }

        if (moveAnimasi > 0)
        {
            animator.SetFloat("JumpX", horizontal);
            animator.SetFloat("JumpZ", vertical);
        }
        else
        {
            if (angle < 35f)
            {
                //print("Belakang");
                animator.SetFloat("JumpX", 0);
                animator.SetFloat("JumpZ", -1);

            }
            else if (angle < 145 && designKarakter.localEulerAngles.y < 180)
            {
                //print("Kiri");
                animator.SetFloat("JumpX", -1);
                animator.SetFloat("JumpZ", 0);
            }
            else if (angle < 145 && designKarakter.localEulerAngles.y > 180)
            {
                //print("Kanan");
                animator.SetFloat("JumpX", 1);
                animator.SetFloat("JumpZ", 0);
            }
            else if (angle < 180)
            {
                //print("Depan");
                animator.SetFloat("JumpX", 0);
                animator.SetFloat("JumpZ", 1);
            }
            else
            {
                //print("Depan");
                animator.SetFloat("JumpX", 0);
                animator.SetFloat("JumpZ", 1);
            }
        }

    }

    public void SetPosition(Vector3 setV3)
    {
        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            operation = false;
            yield return new WaitForSeconds(0.1f);
            transform.position = setV3;
            yield return new WaitForSeconds(0.1f);
            operation = true;
        }
    }
}
