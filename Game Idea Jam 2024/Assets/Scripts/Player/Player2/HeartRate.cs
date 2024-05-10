using UnityEngine;
using UnityEngine.UI;

public class HeartRateDisease : MonoBehaviour
{
    PlayerMovement playerMovement;
    PlayerHealth playerHealth;

    public float heartRate;
    float maxHeartRate = 10f;

    public Scrollbar heartRateBar;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerHealth = GetComponent<PlayerHealth>();

        heartRateBar.size = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(!playerHealth.hasDied) heartRateBar.size = heartRate / 10f;

        if(playerMovement.horizontal != 0 || playerMovement.vertical != 0){
            if(heartRate < maxHeartRate) heartRate += 1 * Time.deltaTime;
            else{
                playerHealth.Die();
            }
        }
        else if(playerMovement.horizontal == 0 && playerMovement.vertical == 0){
            if(heartRate > 0) heartRate -= 1 * Time.deltaTime;
        }
    }
}
