using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Animator ar;
    [SerializeField] Canvas canvas;
   [SerializeField] AudioSource click;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        click.Play();
        ar.SetTrigger("run");
        canvas.gameObject.SetActive(false);
        Invoke(nameof(Load),2f);
    }

    private  void Load()
    {
        SceneManager.LoadScene("TheGame");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
