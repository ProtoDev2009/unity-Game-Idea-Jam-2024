using UnityEngine;

public class Medicine : MonoBehaviour
{
    [SerializeField]AudioSource collectCoin;

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.collider.CompareTag("Player2")){
            collectCoin.Play();
            Destroy(gameObject);
        }
    }
}
