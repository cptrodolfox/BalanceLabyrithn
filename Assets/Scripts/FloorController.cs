using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorController : MonoBehaviour {
    private Rigidbody rb;
    public float speed;
    private AudioSource source;
    public AudioClip loose;
    public Transform pickUp;
	// Use this for initialization
    void Awake () {
        source = GetComponent<AudioSource>();
    }
	void Start () {
        rb = GetComponent<Rigidbody>();
        for(int i=0; i < 30; i++){
            Vector3 floorPosition = transform.position;
            Vector3 position = new Vector3(Random.Range(-20.0f,20.0f), 5.0f, Random.Range(-20.0f,20.0f));
            Instantiate(pickUp, position+floorPosition, Quaternion.identity);

        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("escape"))
            Application.Quit();
        if (Input.GetKeyDown(KeyCode.R))
            restartGame();
        if (transform.position.y < 0.0f){
            source.PlayOneShot(loose);
            restartGame();

        }
	}

    void FixedUpdate()
    {
        float moveZ = Input.GetAxis("Horizontal");
        float moveX = Input.GetAxis("Vertical");
        Vector3 rota = new Vector3 (moveX, 0.0f, moveZ);
        Quaternion deltaRot = Quaternion.Euler(rota * Time.deltaTime);
        rb.MoveRotation(rb.rotation * deltaRot);
    }

    void restartGame ()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
