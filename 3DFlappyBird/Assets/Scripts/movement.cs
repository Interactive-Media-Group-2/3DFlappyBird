using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    Rigidbody rb;
    bool startMove = false;
    public float speed = 5f;
    public float jump = 5f;
    [SerializeField] GameObject control;
    public static int score;
    public static int highscore;

    bool canJump = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = jump * transform.up;
            //if (canJump)
            //{
            //    canJump = false;
            //    StartCoroutine(jumping());
            //    StopCoroutine(jumping());
            //}
            //startMove = true;
            rb.useGravity = true;
        }

        if (startMove)
        {
            //rb.AddForce(gameObject.transform.forward * speed, ForceMode.Force);
            transform.position = transform.position + transform.forward * speed * Time.deltaTime;
        }

        if (score > highscore)
        {
            highscore = score;
        }
    }

    IEnumerator jumping()
    {

        rb.velocity = jump * transform.up;
        yield return new WaitForSeconds(0.5f);
        canJump = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Pipe"))
        {
            control.GetComponent<Lose>().SetStop(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Score")
        {
            score++;
        }

        if (other.tag == "Coin")
        {
            score += 2;
        }
    }
}
