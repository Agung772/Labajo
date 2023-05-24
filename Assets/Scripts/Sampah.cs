using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sampah : MonoBehaviour
{
    public int harga;
    private IEnumerator Start()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.angularVelocity = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), Random.Range(-5, 5));
        yield return new WaitForSeconds(2);
        Destroy(rigidbody);
        gameObject.isStatic = true;
    }
    private void OnMouseDown()
    {
        GameObject temp = Instantiate(GameplayManager.instance.textSampah, transform);
        temp.transform.parent = transform.parent;
        temp.transform.eulerAngles = Vector3.zero;
        temp.GetComponent<TextSampah>().text.text = "+ Rp." + harga;
        Destroy(gameObject);
    }
}
