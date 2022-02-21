using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float jumpForce;
    
    private Rigidbody2D _rb;
    private float horizontalAxis;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate(){ //for physics objects
        //translate not used for physics objects normally
        //_rb.transform.Translate(new Vector3(moveSpeed * Time.deltaTime, 0.0f, 0.0f));
    
        //adding force (realistic movements, example for a ball)
        //_rb.AddForce(new Vector2(moveSpeed, 0.0f), ForceMode2D.Force);
    
        //velocity (snappy movements)
        _rb.velocity = new Vector2(moveSpeed * horizontalAxis, _rb.velocity.y);
    }

    public void OnMove(InputAction.CallbackContext context){
        horizontalAxis = context.ReadValue<float>();
    }

    public void OnJump(InputAction.CallbackContext context){
        if(context.performed)
            _rb.AddForce(new Vector2(0.0f, jumpForce),ForceMode2D.Impulse);
    }
    
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.transform.tag == "Enemy"){
            PlayerManager1.isGameOver = true;
            gameObject.SetActive(false);
        }
    }
}