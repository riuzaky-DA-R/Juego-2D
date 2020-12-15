using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float Distance; 
    private bool movingRight= true;
    public Transform GroundDetection;
    public Canvas Deathscreen;
    private bool Dead = false;
    private void Start()
    {
        Deathscreen.enabled = false;
    }
    private void FixedUpdate()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D GrounInfo = Physics2D.Raycast(GroundDetection.position,Vector2.down,Distance);
        if (GrounInfo.collider == false)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Dead = !Dead;
            Deathscreen.enabled = Dead;
            Time.timeScale = (Dead) ? 0 : 1f;
            Destroy(collision.gameObject);
        }
    }
}
