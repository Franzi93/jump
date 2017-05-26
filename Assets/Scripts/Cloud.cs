using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour {
    public int speed;
    public int scoreFactor = 1;
    public int spawnHeight = 0;
    public bool taken = false;
    public bool activated = false;
    private CircleCollider2D coll;
	// Use this for initialization
	void Start () {
        coll = GetComponent<CircleCollider2D>();
        speed = Random.Range(1, 3);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);

        if (taken && coll.enabled )
        {
            GetComponent<CircleCollider2D>().enabled = false;
        }
        if(!taken && !coll.enabled) {
            GetComponent<CircleCollider2D>().enabled = false;
        }
	}


    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag.Equals("Breaker"))
        {
            Destroy(this.gameObject);
        }

    }
}
