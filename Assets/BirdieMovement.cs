using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdieMovement : MonoBehaviour
{
    public Rigidbody2D birdie;
    public GameObject birdieUp;
    public GameObject birdieDown;
    public bool birdieIsAlive = true;
    public float flappieStrength;
    public float wingSpeed;
    float bottomOfScreen = -8f;
    float topOfScreen = 8f;
    public float targetYPosition;
    public float flapInterval = 50f;
    public float birdieMoveSpeed = 2;
    int count;
    public float deadZone = -45;

    public int heightOffset;

    // Start is called before the first frame update
    void Start()
    {
        wingSpeed *= Time.deltaTime;
        flapInterval *= Time.deltaTime;
        StartCoroutine(FlapRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * birdieMoveSpeed * Time.deltaTime) * Time.deltaTime;

        if (transform.position.x < deadZone)
        {
            Debug.Log("Birdie deleted.");
            Destroy(gameObject);
        }
    }



    IEnumerator FlapRoutine()
    {
        while (birdieIsAlive)
        {

            // Calculate a random target y-position within the specified range
            targetYPosition = Random.Range(bottomOfScreen, topOfScreen);
            if (count < 1)
            {
                targetYPosition = topOfScreen;
            }

            // Apply upward force until the birdie reaches the target position
            while (transform.position.y < targetYPosition)
            {
                Debug.Log("Count");
                float flappieSpeed = Random.Range(300, 400) * Time.deltaTime;
                birdie.velocity = Vector2.up * flappieStrength;
                yield return new WaitForSeconds(flappieSpeed);
                
                if (transform.position.y < bottomOfScreen - 5)
                {
                    transform.position = new Vector3(transform.position.x, bottomOfScreen - 5, transform.position.z);
                }
                StartCoroutine(WaitBeforeFlap());
            }
            

            yield return new WaitForSeconds(flapInterval);

            StartCoroutine(WaitBeforeFlap());

        }

    }

    IEnumerator WaitBeforeFlap()
    {
        birdieDown.SetActive(false);
        birdieUp.SetActive(true);
        yield return new WaitForSeconds(wingSpeed);
        birdieUp.SetActive(false);
        birdieDown.SetActive(true);
    }


}

