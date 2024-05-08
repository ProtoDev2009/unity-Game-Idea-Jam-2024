using UnityEngine;

public class BreathingRateDisease : MonoBehaviour
{
    PlayerMovement playerMovement;

    float breathingRate = 0f;
    float maxBreathingRate = 5f;

    void Start(){
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if(playerMovement.horizontal == 0 && playerMovement.vertical == 0){
            if(breathingRate < maxBreathingRate) breathingRate += 1 * Time.deltaTime;
            else{
                // GAME OVER
            }
        }
        else if(playerMovement.horizontal != 0 && playerMovement.vertical != 0){
            if(breathingRate > 0) breathingRate -= 1 * Time.deltaTime;
        }
    }
}
