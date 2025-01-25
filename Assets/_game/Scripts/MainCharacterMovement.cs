using UnityEngine;
using UnityEngine.InputSystem;

public class MainCharacterMovement : MonoBehaviour
{
    //public float Yacceleration; //Up and Down
    public Rigidbody rb;
    public float Xacceleration; //Left and Right
    public float Zacceleration; //Forward and backwards
    InputAction moveAction;
    public Camera camera;
    public float cameraTurnSpeed;
    private Controls controles;
    public Vector2 direccion;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        controles = new();
        rb = this.gameObject.GetComponent<Rigidbody>();
        camera = Camera.main;
        Zacceleration = 50000f;
        Xacceleration = 500f;
        
        
    }
    private void OnEnable()
    {
        controles.Enable();
    }
    private void OnDisable()
    {
        controles.Disable();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        direccion = controles.Base.Move.ReadValue<Vector2>();

    }
    private void FixedUpdate()
    {
        if (direccion.y != 0)
        {
                rb.AddRelativeForce(new Vector3(0 , rb.position.y, rb.position.z + Time.fixedDeltaTime * Xacceleration * direccion.y));
        }
        if (direccion.x != 0)
        {
            if (rb.linearVelocity.x == 0)
                rb.AddForce(new Vector3(rb.position.x + Time.fixedDeltaTime * Zacceleration * direccion.x, rb.position.y, rb.position.z));
        }
    }
           
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("choco con" + collision.gameObject.name);
    }
}
