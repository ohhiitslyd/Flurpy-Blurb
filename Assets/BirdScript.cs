using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public GameObject fallDownWing;
    public GameObject flapUpWing;
    public float flapSpeed;
    public AudioSource flap;


    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        flapSpeed *= Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space)) && birdIsAlive)
        {
            Debug.Log("Bird before change" + myRigidbody.velocity);
            myRigidbody.velocity = Vector2.up * flapStrength;
            Debug.Log("Bird after change" + myRigidbody.velocity);
            StartCoroutine(WaitBeforeFlap());
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
    }

    IEnumerator WaitBeforeFlap()
    {
        if (!flap.isPlaying)
        {
            flap.Play();
        }
        fallDownWing.SetActive(false);
        flapUpWing.SetActive(true);
        yield return new WaitForSeconds(flapSpeed);
        flapUpWing.SetActive(false);
        fallDownWing.SetActive(true);
    }
}

