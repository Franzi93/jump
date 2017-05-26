using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudGenerator : MonoBehaviour {

    public Cloud[] clouds;
    public Transform top;
    public Transform bottom;


    private RandomInt randCloud;
    private RandomInt randAmount;
    private RandomInt randPositionY;

    private float timer=0;

    void Start() {
        randCloud = new RandomInt(0, clouds.Length - 1);
        randAmount = new RandomInt(1, 2);

        
    }

	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            int spawn = randAmount.random();
            for (int i = 0; i < spawn; i++)
            {
                Cloud c = clouds[randCloud.random()];
                randPositionY = new RandomInt((int)bottom.position.y+c.spawnHeight, (int)top.position.y);
                Instantiate(c, new Vector3(transform.position.x, randPositionY.random(),0),transform.rotation,transform);
            }
            timer = Random.Range(0.5f,2f);
        }
        
	}

    void generate(Cloud c)
    {
        Instantiate(c, transform);
    }
}
