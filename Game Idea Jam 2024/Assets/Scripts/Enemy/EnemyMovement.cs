using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    public Transform player2;

    float moveSpeed = 3f;

    private Rigidbody2D rb;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }

    void Update(){

        float distFromPlayer = Vector2.Distance(player.position, transform.position);
        float distFromPlayer2 = Vector2.Distance(player2.position, transform.position);

        if(distFromPlayer < distFromPlayer2 && !player.GetComponent<PlayerHealth>().hasDied){
            // TARGET PLAYER
            ChasePlayer(player);
        }
        else if(distFromPlayer > distFromPlayer2 && !player2.GetComponent<PlayerHealth>().hasDied){
            // TARGET PLAYER2
            ChasePlayer(player2);
        }
        else if(!player.GetComponent<PlayerHealth>().hasDied && !player2.GetComponent<PlayerHealth>().hasDied){
            // CHOOSE A RANDOM PLAYER TO TARGET
            int choosePlayer = Random.Range(0, 1);
            if(choosePlayer == 0) ChasePlayer(player);
            else ChasePlayer(player2);
        }
        else{
            // EVERY PLAYER HAS DIED
        }
    }

    void ChasePlayer(Transform target){
        Vector2 direction = (target.position - transform.position).normalized;
        rb.velocity = direction * moveSpeed;

        // ROTATE TOWARDS PLAYER
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle - 90f));
    }
}
