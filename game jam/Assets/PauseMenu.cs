using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] Image pauseImage;
    bool gameIsPaused = false;
    [SerializeField] AudioSource click;
    // Start is called before the first frame update
    void Start()
    {
        pauseImage.gameObject.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        Pause();
    }

    void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && gameIsPaused == false)
        {
            Debug.Log("ssad");
            pauseImage.gameObject.SetActive(true);

            Time.timeScale = 0f;
            gameIsPaused = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && gameIsPaused == true)
        {
            Debug.Log("ssad");
            pauseImage.gameObject.SetActive(false);

            Time.timeScale = 1f;
            gameIsPaused = false;
        }

    }

    private void ResumeGame()
    {
     
    }

    public void Resume()
    {
        click.Play();
        pauseImage.gameObject.SetActive(false);

        Time.timeScale = 1f;
        gameIsPaused = false;

    }
    public void Quit()
    {
        Application.Quit();
    }
} 


