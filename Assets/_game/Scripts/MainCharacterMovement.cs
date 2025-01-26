using UnityEngine;
using UnityEngine.InputSystem;

public class MainCharacterMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float verticalAcceleration; //Forward and backwards 
    public float horizontalAcceleration; //Left and Right
    InputAction moveAction;
    public Camera mainCamera;
    private Controls controles;
    public Vector2 direccion;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        controles = new();
        rb = this.gameObject.GetComponent<Rigidbody>();
        mainCamera = Camera.main;
        horizontalAcceleration = 300f;
        verticalAcceleration = 300f;
    }
    private void OnEnable()
    {
        controles.Enable();
    }
    private void OnDisable()
    {
        controles.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        transform.forward = mainCamera.transform.forward;
        direccion = controles.Base.Move.ReadValue<Vector2>();
    }
    
    private void FixedUpdate()
    {
        rb.AddForce(transform.forward * (Time.fixedDeltaTime * verticalAcceleration * direccion.y) );
        rb.AddForce(transform.right * (Time.fixedDeltaTime * horizontalAcceleration * direccion.x) );
    }
}
