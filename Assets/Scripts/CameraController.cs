using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float yOffset;
    [SerializeField] private Transform trackingObject;

    private void Update()
    {
        Vector2 pos = trackingObject.position;
        pos.y += yOffset;

        transform.position = Vector2.Lerp(transform.position, pos, 0.3f);
    }
}
