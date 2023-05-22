using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPlayer : MonoBehaviour
{
    public float health;
    public float o_health;

    [SerializeField]
    Image barHealth;

    private void Start()
    {
        o_health = health;
    }
    private void Update()
    {
        o_health -= Time.deltaTime * 0.1f;
        barHealth.fillAmount = o_health / health;
    }
}
