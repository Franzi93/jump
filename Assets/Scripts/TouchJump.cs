using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchJump : MonoBehaviour {
    private Cloud c;
    private int combo = 0;

    public Vector2 sit;
    public Vector2 dir;

    private Rigidbody2D rigid;
    public float force = 1f;
    public bool sits = false;
    public float speed;
    public GameObject respawner;
    private bool onGround = true;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        respawner = GameObject.FindGameObjectWithTag("Respawn");
        respawn();
    }
    

    // Update is called once per frame
    void Update() {
        if (sits || onGround) {

            if (sits) { 
                transform.position = (Vector2)c.transform.position + sit;
            }

            if (Input.touchCount > 0)
                if (Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                    moveToPoint(Input.touches[0].deltaPosition.normalized);
                }
            {
               // moveToPoint(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position));
            }
            if (Input.GetMouseButtonDown(0))
            {
                moveToPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            }
        }
    }

    void moveToPoint(Vector2 pos) {
        if (c) {
            c.isPlayerSittingOn = false;
        }
        dir = pos - (Vector2)transform.position;
        rigid.AddForce(dir*force, ForceMode2D.Impulse);
        onGround = false;
        sits = false;
    }
    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag.Equals("Ground"))
        {
            rigid.velocity = Vector2.zero;
            rigid.angularVelocity = 0f;
            combo = 0;
            onGround = true;
        }
    }

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.tag.Equals("Cloud"))
        {
            sits = true;
            c = coll.gameObject.GetComponent<Cloud>();
            c.isPlayerSittingOn = true;
            rigid.velocity = Vector2.zero;
            rigid.angularVelocity = 0f;
            if (!c.isUsedBefore)
            {
                ++combo; 
                GameManager.points += 100 * combo*c.scoreFactor;
                c.isUsedBefore = true;
            }
        }
        if (coll.tag.Equals("Breaker"))
        {
            respawn();
        }
       
    }

    private void respawn()
    {
        transform.position = respawner.transform.position;
    }
}
