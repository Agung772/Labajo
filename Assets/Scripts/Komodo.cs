using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Komodo : MonoBehaviour
{
    Transform camera;
    IEnumerator Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
        yield return new WaitForSeconds(2);
        Destroy(GetComponent<Rigidbody>());
    }
    private void Update()
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, camera.eulerAngles.y, transform.eulerAngles.z);
    }
}
