using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchJump : MonoBehaviour {
    private Cloud c;
    private int combo = 0;

    public Vector2 sit;

    private Vector2 posi;
    public Vector2 dir;

    public float range = 3f;
    public bool sits = false;
    public float speed;
    public GameObject respawner;
    private bool onGround = true;

    void Start()
    {
        respawner = GameObject.FindGameObjectWithTag("Respawn");
        respawn();
        posi = transform.position;
    }
    

    // Update is called once per frame
    void Update() {
        if (sits || onGround) {

            if (sits) { 
                transform.position = (Vector2)c.transform.position + sit;
            }
            if (Input.touchCount > 0)
            {
                moveToPoint(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position));
            }
            if (Input.GetMouseButtonDown(0))
            {
                moveToPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            }
        }
    }

    void moveToPoint(Vector2 pos) {
        dir = pos - (Vector2)transform.position;
        GetComponent<Rigidbody2D>().AddForce(dir, ForceMode2D.Impulse);
        onGround = false;
        sits = false;
    }
    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag.Equals("Ground"))
        {
            combo = 0;
            onGround = true;
        }
    }

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.tag.Equals("Cloud"))
        {
            sits = true;
            c = coll.gameObject.GetComponent<Cloud>();
            if (!c.activated)
            {
                ++combo; 
                GameManager.points += 100 * combo*c.scoreFactor;
                c.activated = true;
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
