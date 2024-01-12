using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KunaiScript : MonoBehaviour
{
    [SerializeField]
    private Vector2 throwForce;

    private bool isActive = true;

    private Rigidbody2D rb;
    private BoxCollider2D kunaiCollider;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        kunaiCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && isActive)
        {
            //add force on kunai when user press right button of the mouse
            rb.AddForce(throwForce, ForceMode2D.Impulse);
            rb.gravityScale = 1;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isActive)
        {
            return;
        }
        isActive = false;

        if (collision.collider.tag == "Target")
        {
            //set velocity of kunai zero when hit to the traget
            rb.velocity = new Vector2(0, 0);
            rb.bodyType = RigidbodyType2D.Kinematic;
            //Kunai transform parent set to traget transform
            this.transform.SetParent(collision.collider.transform);

            kunaiCollider.offset = new Vector2(kunaiCollider.offset.x, -0.012f);
            //deceress the size of kunai to skack perfect
            kunaiCollider.size = new Vector2(kunaiCollider.size.x, 0.033f);
           
        }
        else if (collision.collider.tag == "Kunai")
        {
            //change the y velocity when kunai hits other kunai
            rb.velocity = new Vector2(rb.velocity.x, -2);
        }
    }
   
}

