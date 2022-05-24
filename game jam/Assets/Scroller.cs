using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D box;
    [SerializeField] Transform[] Obstecle;
    Health health;

    float hight;

    [SerializeField] public float scrollSpeed;
    // Start is called before the first frame update
    void Start()
    {
        health = FindObjectOfType<Health>();
        rb = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();

        hight = box.size.y;

        box.enabled = false;

        ResetLadder();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0, scrollSpeed);

        if (transform.position.y < -hight)
        {
            Vector2 resetPos = new Vector2(0, hight * 2f);

            transform.position = (Vector2) transform.position + resetPos;
            ResetLadder();
        }
        if (health.dead == true)
        {
            scrollSpeed = 0;
        }
    }


    void ResetLadder()
    {
        foreach(Transform obst in Obstecle)
        {
            obst.localPosition = new Vector3(Random.Range(0.800f, -0.884f), obst.localPosition.y, 0);

        }
    }
}
