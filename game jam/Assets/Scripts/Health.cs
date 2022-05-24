using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    Animator ar;
    int maxHealth = 100;
    [SerializeField] int currentHealth;
    PlayerMovement player;
    public bool dead;
    CapsuleCollider2D capsule;
    [SerializeField] Animator black;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerMovement>();
        ar = GetComponent<Animator>();
        currentHealth = maxHealth;
        capsule = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDmg(int dmg)
    {
        currentHealth -= dmg;

        if (currentHealth <= 0)
        {
            Dead();
        }
    }

    void Dead()
    {
        black.SetTrigger("run");
        ar.SetTrigger("dead");
        player.enabled = false;
        Invoke(nameof(Reload), 2f);
        capsule.enabled = false;
        dead = true;
    }


    void Reload()
    {
        int load = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(load);
    }
}
