using UnityEngine;

public class ExitGate : MonoBehaviour
{
    public ExitPass exitPass;
    public GameObject WinPanel;

    public GameManager gameManager;

    [SerializeField] AudioSource errorSound;
    [SerializeField] AudioSource winSound;

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.collider.CompareTag("Player") || collision.collider.CompareTag("Player2")){
            if(exitPass.LevelCleared){
                WinPanel.SetActive(true);
                Time.timeScale = 0f;
                winSound.Play();

                gameManager.gameMusic.Stop();
            }
            else{
                errorSound.Play();
            }
        }
    }
}
