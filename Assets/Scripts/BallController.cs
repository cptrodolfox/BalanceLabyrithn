using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {
    private Rigidbody rb;
    private int score;
    private AudioSource source;
    public AudioClip pickSound;
    public AudioClip winSound;
	// Use this for initialization
    void Awake (){
        source = GetComponent<AudioSource>();
    }
	void Start () {
        score = 0;
        rb = GetComponent<Rigidbody>();
		
	}
	
	// Update is called once per frame
	void Update () {
        if (score == 30)
        {
            source.PlayOneShot(winSound);
            restartGame();
        }
	}
    void restartGame(){

        Application.LoadLevel(Application.loadedLevel);
    }

    void OnCollisionEnter( Collision col )
    {
        if (col.gameObject.CompareTag("Collectable"))
        {
            col.gameObject.SetActive(false);
            score = score + 1;
            transform.localScale += new Vector3(0.1f,0.1f,0.1f);
            rb.mass += 0.001f;
            source.PlayOneShot(pickSound);
        }
    }
}
