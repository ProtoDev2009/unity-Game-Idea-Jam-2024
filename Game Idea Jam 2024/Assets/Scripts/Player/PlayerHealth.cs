using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    float currentHealth;

    public bool hasDied = false;

    public Scrollbar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.size = 1;
    }

    void Update(){
        healthBar.size = currentHealth / 100f;
    }

    public void TakeDamage(int damage){
        if(currentHealth > 0) currentHealth -= damage;
        else Die();

        // Debug.Log(transform.tag + " " + currentHealth);
    }

    public void Die(){
        hasDied = true;
        //OTHER DIE FUNCTIONS
    }
}
