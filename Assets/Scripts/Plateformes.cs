using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plateformes : MonoBehaviour
{

    [SerializeField] private float RestorColliderDelay = 1f;

    protected Collider2D Col;

    // Start is called before the first frame update
    protected void Start()
    {
        Col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Input.GetAxisRaw("Vertical") < 0)
        {
            //col.enabled = false;
            StartCoroutine(ChangeColliderState());
        }
    }

    private IEnumerator ChangeColliderState()
    {
        Col.enabled = false;
        yield return new WaitForSeconds(RestorColliderDelay);
        Col.enabled = true;
    }
}

