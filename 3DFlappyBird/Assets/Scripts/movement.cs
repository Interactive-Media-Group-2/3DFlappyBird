using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    Rigidbody rb;
    bool startMove = false;
    public float speed = 5f;
    public float jump = 5f;
    [SerializeField] GameObject control, left, right;
    int positions;
    public bool canMove;

    bool canJump = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        positions = 1;
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
            if (!canMove)
            {
                startMove = true;
            }
            rb.useGravity = true;
        }
        if (canMove)
        {
            if (Input.GetKeyDown(KeyCode.A) && positions > 0)
            {
                transform.position += new Vector3(left.transform.position.x, 0, 0);
                positions--;
            }
            if (Input.GetKeyDown(KeyCode.D) && positions < 2)
            {
                transform.position += new Vector3(right.transform.position.x, 0, 0);
                positions++;
            }
        }

        if (startMove)
        {
            //rb.AddForce(gameObject.transform.forward * speed, ForceMode.Force);
            transform.position = transform.position + transform.forward * speed * Time.deltaTime;
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
        if (collision.collider.CompareTag("Pipe") || collision.collider.CompareTag("Ground"))
        {
            control.GetComponent<Lose>().SetStop(true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Points"))
        {
            control.GetComponent<Lose>().AddScore();
        }
    }
}
