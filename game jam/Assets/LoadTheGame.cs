using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadTheGame : MonoBehaviour
{
    [SerializeField] Animator ar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Invoke(nameof(Load), 2f);
    }

    void Load()
    {
        ar.SetTrigger("run");
        Invoke(nameof(MainMenu), 1f);
    }
    void MainMenu()
    {

        SceneManager.LoadScene("MainMenu");
    }
}