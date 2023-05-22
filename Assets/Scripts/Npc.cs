using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour
{
    Transform cam;
    public Animator animator;

    Vector3 animasiV3;

    private void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").transform;

    }

    private void Update()
    {
        transform.eulerAngles = new Vector3(0, cam.eulerAngles.y, 0);


        animasiV3 = transform.position - cam.position;
        animator.SetFloat("X", animasiV3.x);
        animator.SetFloat("Z", animasiV3.z);
    }
}
