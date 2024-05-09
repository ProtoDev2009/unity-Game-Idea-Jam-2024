using UnityEngine;
using UnityEngine.UI;

public class BreathingRateDisease : MonoBehaviour
{
    PlayerMovement playerMovement;
    PlayerHealth playerHealth;

    public float breathingRate = 0f;
    float maxBreathingRate = 10f;

    public Scrollbar breatheBar;

    void Start(){
        playerMovement = GetComponent<PlayerMovement>();
        playerHealth = GetComponent<PlayerHealth>();

        breatheBar.size = maxBreathingRate / 10;
    }

    void Update()
    {
        if(!playerHealth.hasDied) breatheBar.size = breathingRate / 10;

        if(playerMovement.horizontal == 0 && playerMovement.vertical == 0){
            if(breathingRate < maxBreathingRate) breathingRate += 1 * Time.deltaTime;
            else{
                // GAME OVER
                playerHealth.Die();
            }
        }
        else if(playerMovement.horizontal != 0 || playerMovement.vertical != 0){
            if(breathingRate > 0) breathingRate -= 1 * Time.deltaTime;
        }
    }
}
