using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformeSelfDestruct : MonoBehaviour
{

    [SerializeField] float FallingDelay =3f;
    [SerializeField] float RespawnDelay =3f;

    private Collider2D col;
    private Rigidbody2D rb;
    private bool IsWaitingForFall;
    private Vector2 StartPosition;

    // Start is called before the first frame update
    void Start()
    {
        col=GetComponent<Collider2D>();
        rb=GetComponent<Rigidbody2D>();
        StartPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !IsWaitingForFall)
        {
            IsWaitingForFall = true;
            Invoke("Fall", FallingDelay);
        }
    }

    private void Fall()
    {
        col.enabled = false;
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    private void Respawn()
    {
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0;
        transform.rotation = Quaternion.identity;
        rb.bodyType= RigidbodyType2D.Static;
        transform.position = StartPosition;
        col.enabled = true;
    }
}
