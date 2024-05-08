using UnityEngine;

public class Medicine : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision){
        if(collision.collider.CompareTag("Player2")){
            Destroy(gameObject);
        }
    }
}
