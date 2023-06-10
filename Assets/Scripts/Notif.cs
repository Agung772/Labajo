using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Notif : MonoBehaviour
{
    public TextMeshProUGUI notifText;
    private void Start()
    {
        Destroy(gameObject, 3);
    }
}
