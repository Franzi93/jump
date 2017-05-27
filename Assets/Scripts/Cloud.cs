using UnityEngine;

public class Cloud : MonoBehaviour {
    public int speed;
    public int scoreFactor = 1;
    public int spawnHeight = 0;

    public bool isPlayerSittingOn = false;
    public bool isUsedBefore = false;
    public float timeForCoolDown = 1f;

    private CircleCollider2D coll;
    private float coolDown;

	// Use this for initialization
	void Start () {
        coll = GetComponent<CircleCollider2D>();
        speed = Random.Range(1, 3);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);

        if (isPlayerSittingOn && coll.enabled )
        {
            GetComponent<CircleCollider2D>().enabled = false;
        }
        if(!isPlayerSittingOn && !coll.enabled) {
            if (coolDown <= 0)
            {
                GetComponent<CircleCollider2D>().enabled = false;
                coolDown = timeForCoolDown;
            }
            else {
                coolDown -= Time.deltaTime;
            }
        }
	}


    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag.Equals("Breaker"))
        {
            Destroy(gameObject);
        }

    }
}
