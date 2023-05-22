using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PohonController : MonoBehaviour
{
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(2);
        Destroy(GetComponent<Rigidbody>());
    }
}
