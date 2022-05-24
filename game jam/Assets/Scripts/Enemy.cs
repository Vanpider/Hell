using UnityEngine;

public class Enemy : MonoBehaviour
{
    Health healt;
    Rigidbody2D rb;
    [SerializeField] Transform target;
    [SerializeField] float speed;
    [SerializeField] float chaseSpeed;
    bool isFlipped;
    [SerializeField] float chaseRange;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        healt = FindObjectOfType<Health>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            healt.TakeDmg(100);
        }
    }
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);



    }



    void Flip()
    {
        transform.Rotate(0, 180, 0);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        speed = -speed;
        Flip();
    }

   
}
