using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject toFollow;
    public float lerp;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (toFollow) {
            Vector2 pos = transform.position;

            transform.position = new Vector3(transform.position.x, Mathf.Lerp(pos.y, toFollow.transform.position.y, lerp),transform.position.z);
        }
	}
}
