using UnityEngine;
using UnityEngine.UI;

public class ExitPass : MonoBehaviour
{
    private float maxProgress = 20f;
    public float currentProgress = 0f;

    public bool LevelCleared = false;

    public PlayerHealth playerHealth;
    public PlayerMovement playerMovement;

    public Scrollbar progressBar;

    void Start(){
        progressBar.size = maxProgress / 20f;
    }

    void Update(){
        progressBar.size = currentProgress / 20f;
    }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.CompareTag("Player"))GetComponent<AudioSource>().Play();
    }

    void OnTriggerExit2D(Collider2D collider){
        if(collider.CompareTag("Player"))GetComponent<AudioSource>().Stop();
    }

    void OnTriggerStay2D(Collider2D collider){
        if(collider.CompareTag("Player") && !playerHealth.hasDied && (playerMovement.horizontal == 0 && playerMovement.vertical == 0)){

            if(currentProgress < maxProgress) {
                currentProgress += 1 * Time.deltaTime; 
            }
            else LevelCleared = true;
        }
    }
}
