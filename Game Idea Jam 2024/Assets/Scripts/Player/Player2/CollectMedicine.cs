using UnityEngine;

public class CollectMedicine : MonoBehaviour
{
    public int medicines = 0;

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.collider.CompareTag("Medicine")){
            medicines++;
        }
        else if(collision.collider.CompareTag("Player")){
            if(medicines > 0) medicines--;
        }
    }
}
