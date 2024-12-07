using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyBehaviour : MonoBehaviour
{
    [SerializeField] private float _velocity = 1.5f;
    [SerializeField] private float _rotaionSpeed = 10f;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            rb.velocity = Vector2.up * _velocity;
            GetComponent<Animator>().SetTrigger("Fly");
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) 
        {

            rb.velocity = Vector2.up * _velocity;
            GetComponent<Animator>().SetTrigger("Fly");
        }

    }
    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0,0,rb.velocity.y * _rotaionSpeed);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.Instance.GameOver();
    }
}
