using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    bool isPaused;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        Pause();
    }
    public void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
            isPaused = true;
 
        }else if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
            isPaused = false;
        }
    }
}
