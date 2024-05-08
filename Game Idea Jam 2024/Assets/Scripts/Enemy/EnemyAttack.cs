using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private PlayerHealth playerHealth;
    private PlayerHealth player2Health;

    private EnemyMovement enemyMovement;

    private int damage;

    void Start(){
        enemyMovement = GetComponent<EnemyMovement>();

        playerHealth = enemyMovement.player.GetComponent<PlayerHealth>();
        player2Health = enemyMovement.player2.GetComponent<PlayerHealth>();
    }

    void OnTriggerStay2D(Collider2D collider){

        if(collider.CompareTag("Player")){
            // ATTACK PLAYER
            StartCoroutine(DamagePlayer(playerHealth));
        }
        else if(collider.CompareTag("Player2")){
            // ATTACK PLAYER2
            StartCoroutine(DamagePlayer(player2Health));
        }
    }

    IEnumerator DamagePlayer(PlayerHealth target){
        damage = Random.Range(0, 10);

        target.TakeDamage(damage);
        yield return new WaitForSeconds(1);
    }
}
