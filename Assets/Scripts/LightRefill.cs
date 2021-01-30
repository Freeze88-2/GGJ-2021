using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRefill : MonoBehaviour
{
    [SerializeField] private float refillAmmount;
    [SerializeField] private Light fire;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Light"))
        {
            fire.LifePercentage += refillAmmount / 10f * Time.deltaTime;
        }
    }
}
