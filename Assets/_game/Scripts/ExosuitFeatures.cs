using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class ExosuitFeatures : MonoBehaviour
{
    private Controls controles;
    public Light bulb;
    public MainCharacterMovement movRef;
    public float turboValue;
    public bool turboActive;
    public Lightsystem Light;
    
    
    private void Awake()
    {
        turboActive = false;
        turboValue = 1000f;
        movRef = this.gameObject.GetComponent<MainCharacterMovement>();
        controles = new();
        //loadsystems
        Light = FindAnyObjectByType<Lightsystem>();

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
            Light.IsActive = bulb.enabled;

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
        movRef.Xacceleration = movRef.Xacceleration+turboValue;
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);
        movRef.Xacceleration = movRef.Xacceleration - turboValue;
        turboActive = false;
        //After we have waited 5 seconds print the time again.
        
    }

}
