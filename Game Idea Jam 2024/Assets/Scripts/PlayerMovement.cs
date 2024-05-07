using UnityEditor.Rendering;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] KeyCode forwardKey;
    [SerializeField] KeyCode backwardKey;
    [SerializeField] KeyCode leftKey;
    [SerializeField] KeyCode rightKey;

    [SerializeField] float speed = 5f;

    float horizontal;
    float vertical;

    private Vector2 moveDir;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //INPUT
        // :: Vertical
        if(Input.GetKey(forwardKey)) vertical = 1;
        else if(Input.GetKey(backwardKey)) vertical = -1;
        else vertical = 0;

        // :: Horizontal
        if(Input.GetKey(rightKey)) horizontal = 1;
        else if(Input.GetKey(leftKey)) horizontal = -1;
        else horizontal = 0;

        //Setup Movement Direction
        moveDir = new Vector2(horizontal, vertical);
    }

    void FixedUpdate(){
        //MOVEMENT
        rb.velocity = moveDir * speed;
    }
}
