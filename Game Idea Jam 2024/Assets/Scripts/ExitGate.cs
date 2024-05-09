using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitGate : MonoBehaviour
{
    public ExitPass exitPass;

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.collider.CompareTag("Player") || collision.collider.CompareTag("Player2")){
            if(exitPass.LevelCleared){
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
