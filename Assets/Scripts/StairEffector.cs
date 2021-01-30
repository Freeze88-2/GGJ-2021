using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairEffector : MonoBehaviour
{
    private Movement player;
    private Vector3 end;
    private Vector3 start;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
        start = transform.GetChild(0).position;
        end = transform.GetChild(1).position;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.OnStairs = true;
            player.points = (start, end);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.OnStairs = false;
        }
    }
}
