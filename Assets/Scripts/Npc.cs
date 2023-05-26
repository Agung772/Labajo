using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour
{
    Transform cam;
    public Animator animator;

    Vector3 animasiV3;

    IEnumerator Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").transform;
        yield return new WaitForSeconds(2);
        Destroy(GetComponent<Rigidbody>());
    }

    private void Update()
    {
        transform.eulerAngles = new Vector3(0, cam.eulerAngles.y, 0);


        animasiV3 = transform.position - cam.position;
        Vector3 v3 = animasiV3.normalized;

        animator.SetFloat("X", v3.x);
        animator.SetFloat("Z", v3.z);
    }
}
