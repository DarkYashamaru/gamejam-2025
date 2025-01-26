using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using UnityEngine.Serialization;

public class ExosuitFeatures : MonoBehaviour
{
    private Controls controles;
    public Light bulb;
    public MainCharacterMovement movRef;
    public float turboValue;
    public bool turboActive;
    public Lightsystem LightSystem;
    public TurboSystem TurboSystem;
    
    
    private void Awake()
    {
        turboActive = false;
        turboValue = 1000f;
        movRef = this.gameObject.GetComponent<MainCharacterMovement>();
        controles = new();
        //loadsystems
        LightSystem = FindAnyObjectByType<Lightsystem>();
        TurboSystem = FindAnyObjectByType<TurboSystem>();

    }

    private void OnEnable()
    {
        controles.Base.LightTrigger.performed += TurnLight;
        controles.Base.Turbo.performed += Turbo;
        controles.Enable();

    }
    private void OnDisable()
    {
        controles.Base.LightTrigger.performed -= TurnLight;
        controles.Base.Turbo.performed += Turbo;
        controles.Disable();
    }

    void TurnLight(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            if (bulb.enabled)
            {
                bulb.enabled = false;
            }
            else
            {
                bulb.enabled = true;
            }
            LightSystem.IsActive = bulb.enabled;

            //Debug.Log("Click a la linterna");
        }
    }
    void Turbo(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && !turboActive)
        {
            StartCoroutine(TurboEnum());
            
        }
        

    }
    IEnumerator TurboEnum()
    {
        turboActive = true;
        TurboSystem.IsActive = true;
        movRef.Xacceleration = movRef.Xacceleration+turboValue;
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);
        movRef.Xacceleration = movRef.Xacceleration - turboValue;
        turboActive = false;
        TurboSystem.IsActive = false;
        //After we have waited 5 seconds print the time again.
        
    }

}
