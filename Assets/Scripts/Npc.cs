using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour
{
    public string namaNPC, dialog;
    [SerializeField] GameObject dialogManagerPrefab;

    Transform camera;
    public Animator animator;

    Vector3 animasiV3;

    IEnumerator Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
        yield return new WaitForSeconds(2);
        Destroy(GetComponent<Rigidbody>());
    }

    private void Update()
    {
        AnimasiPlayer();
    }

    Vector3 directionC;
    public float angle;
    void AnimasiPlayer()
    {
        //Input move
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        animator.transform.eulerAngles = new Vector3(0, camera.eulerAngles.y, 0);

        //Calculate angle player
        Vector3 forward = -transform.forward;
        forward.y = 0;

        angle = Vector3.Angle(directionC, forward);

        directionC = camera.position - transform.position;
        directionC.y = 0;

        if (angle < 45)
        {
            print("Depan");
            animator.SetFloat("X", 0);
            animator.SetFloat("Z", -1);

        }
        else if (angle < 180)
        {
            print("Belakang");
            animator.SetFloat("X", 0);
            animator.SetFloat("Z", 1);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) UIGameplay.instance.NotifUI(true, "Tekan F untuk interaksi");
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) UIGameplay.instance.NotifUI(false, null);
    }

    bool cd;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.F) && !cd)
            {
                cd = true;

                StartCoroutine(Coroutine());
                IEnumerator Coroutine()
                {
                    GameObject temp = Instantiate(dialogManagerPrefab, transform);
                    temp.GetComponent<DialogManager>().SetDialog(namaNPC, dialog);
                    yield return new WaitForSeconds(1);
                    cd = false;
                }


            }
        }
    }
}
