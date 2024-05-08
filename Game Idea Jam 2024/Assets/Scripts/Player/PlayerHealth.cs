using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;

    public bool hasDied = false;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage){
        if(currentHealth > 0) currentHealth -= damage;
        else Die();

        Debug.Log(transform.tag + " " + currentHealth);
    }

    void Die(){
        Debug.Log("Player Died");
        hasDied = true;
        //OTHER DIE FUNCTIONS
    }
}
