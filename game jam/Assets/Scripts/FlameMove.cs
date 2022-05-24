using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameMove : MonoBehaviour
{
    [SerializeField] float speed;
    Health health;
    Scroller scroller;
    bool firstSpeed = false;
    bool secSpeed = false;
    bool thirdSpeed = false;
    bool fourthSpeed = false;
    bool fifthSpeed = false;
    bool sixthSpeed = false;
    // Start is called before the first frame update
    void Start()
    {
        scroller = FindObjectOfType<Scroller>();
        health = FindObjectOfType<Health>(); 
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, speed * Time.deltaTime, 0) ;

        if(gameObject.transform.position.y >= 10 && firstSpeed == false)
        {
            scroller.scrollSpeed += 0.1f;
            speed += 0.1f;
            firstSpeed = true;
        } 
        if(gameObject.transform.position.y >= 20 && secSpeed == false)
        {
            scroller.scrollSpeed += 0.1f;
            speed += 0.1f;
            secSpeed = true;
        }
        if (gameObject.transform.position.y >= 30 && thirdSpeed == false)
        {
            scroller.scrollSpeed += 0.2f;
            speed += 0.2f;
            thirdSpeed = true;
        }

        if (gameObject.transform.position.y >= 50 && fourthSpeed == false)
        {
            scroller.scrollSpeed += 0.4f;
            speed += 0.4f;
            fourthSpeed = true;
        }
        if (gameObject.transform.position.y >= 100 && fifthSpeed == false)
        {
            scroller.scrollSpeed += 0.8f;
            speed += 0.8f;
            fifthSpeed = true;
        }
        if (gameObject.transform.position.y >= 150 && sixthSpeed == false)
        {
            scroller.scrollSpeed += 1f;
            speed += 1f;
            sixthSpeed = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            health.TakeDmg(1000);
        }
    }
}
