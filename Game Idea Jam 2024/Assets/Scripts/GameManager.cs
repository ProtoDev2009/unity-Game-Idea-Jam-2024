using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject Panel;
    public GameObject losePanel;

    public AudioSource gameMusic;

    public GameObject CreditsPanel;

    public PlayerHealth playerHealth;
    public PlayerHealth player2Health;

    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(Panel.activeInHierarchy){
                 Panel.SetActive(false); 
                 gameMusic.Play();
                 Time.timeScale = 1f;
            }
            else {
                Panel.SetActive(true); 
                gameMusic.Stop();
                Time.timeScale = 0f;
            }
        }

        if(playerHealth.hasDied && player2Health.hasDied){
            losePanel.SetActive(true);
            gameMusic.Stop();
            Time.timeScale = 0f;
        }
    }

    public void LoadNextLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ReloadLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void Quit(){
        Application.Quit();
    }

    public void SetCredits(){
        if(CreditsPanel.activeInHierarchy) CreditsPanel.SetActive(false);
        else CreditsPanel.SetActive(true);
    }
}
