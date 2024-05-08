using UnityEngine;
using UnityEngine.UI;

public class ExitPass : MonoBehaviour
{
    private float maxProgress = 20f;
    public float currentProgress = 0f;

    public PlayerHealth playerHealth;

    public Scrollbar progressBar;

    void Start(){
        progressBar.size = maxProgress / 20f;
    }

    void Update(){
        progressBar.size = currentProgress / 20f;
    }

    void OnTriggerStay2D(Collider2D collider){
        if(collider.CompareTag("Player") && !playerHealth.hasDied){
            if(currentProgress < maxProgress) currentProgress += 1 * Time.deltaTime;
            else Win();
        }
    }

    void Win(){
        Debug.Log("Win");
    }
}
