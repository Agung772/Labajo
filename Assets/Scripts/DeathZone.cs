using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public Transform spawnPlayer;
    bool cd;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && !cd)
        {
            cd = true;
            StartCoroutine(Coroutine());
            IEnumerator Coroutine()
            {
                print("Death");
                PlayerController.instance.SetPosition(spawnPlayer.position);
                yield return new WaitForSeconds(0.5f);
                cd = false;
            }
        }
    }
}
