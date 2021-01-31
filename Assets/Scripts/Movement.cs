using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private TilemapCollider2D tile;
    [SerializeField] private Animator  _animator;
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

    Vector2 dira;
    // Update is called once per frame
    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        if (y > 0)
        {
            OnStairs = true;
        }
        else if (y < 0 && transform.position.y < 0)
        {
            OnStairs = false;
        }

        if (x != 0)
        {
            _animator.SetBool("idle", false);
        }
        else
        {
            _animator.SetBool("idle", true);
        }

        tile.enabled = OnStairs;

        RaycastHit2D hit = Physics2D.Raycast(transform.position +
            (Vector3.down * 0.5f), Vector2.down, 10, LayerMask.GetMask("Ground"));
        Vector2 dir = -Vector2.Perpendicular(hit.normal).normalized;

        dira = dir;
        moveVector = (dir * x) * speed;

        

        if (!Physics2D.OverlapCircle(transform.position +
            (Vector3.down * 0.5f), 0.15f, LayerMask.GetMask("Ground")) && !OnStairs)
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
        Gizmos.DrawLine(transform.position, new Vector3(dira.x, dira.y, 0) + transform.position);
    }
}
