using UnityEngine;

public class GainHealth : MonoBehaviour
{
    [SerializeField] CollectMedicine player2;
    BreathingRateDisease playerHealth;

    void Start(){
        playerHealth = GetComponent<BreathingRateDisease>();
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.collider.CompareTag("Player2")){
            if(player2.medicines > 0) playerHealth.breathingRate -= Random.Range(5f, 7f);
        }
    }
}
