using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class ExosuitFeatures : MonoBehaviour
{
    private Controls controles;
    public Light bulb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    private void Awake()
    {
        controles = new();

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

    // Update is called once per frame
    void TurnLight(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            if (bulb.enabled)
                bulb.enabled = false;
            else bulb.enabled = true;
            Debug.Log("Click a la linterna");
        }
    }
    void Turbo(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            //StartCoroutine(ExampleCoroutine())
        }

    }
    IEnumerator ExampleCoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }

}
