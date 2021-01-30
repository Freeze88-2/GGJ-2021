using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    private Vector2 moveVector;
    private bool lastTurn = false;

    public bool OnStairs;
    public (Vector3 start, Vector3 end) points;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = OnStairs ? Input.GetAxis("Vertical") : 0;

        if (OnStairs)
        {
            moveVector = ((Vector3.right * x) + ((points.end - points.start).normalized * y)) * speed;
        }
        else
        {
            moveVector = (new Vector2(x, y) * speed);
        }

        if (!Physics2D.OverlapCircle(transform.position +
            (Vector3.down * 0.5f), 0.1f, LayerMask.GetMask("Ground")) && !OnStairs)
        {
            moveVector.y = -200f;
        }

        Vector3 euler = transform.rotation.eulerAngles;

        if (moveVector.x < 0)
        {
            lastTurn = true;
        }
        else if (moveVector.x > 0)
        {
            lastTurn = false;
        }

        if (lastTurn)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(euler.x, 180, euler.z), 0.1f);
        }
        else if (!lastTurn)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(euler.x, 0, euler.z), 0.1f);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = moveVector * Time.fixedDeltaTime;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position + (Vector3.down * 0.5f), 0.1f);
    }
}
