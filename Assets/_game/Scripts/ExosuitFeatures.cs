using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using UnityEngine.Serialization;

public class ExosuitFeatures : MonoBehaviour
{
    private Controls controles;
    public Light[] lights;
    public MainCharacterMovement movRef;
    public float turboValue;
    public bool turboActive;
    public bool lightActive;
    public Lightsystem LightSystem;
    public TurboSystem TurboSystem;
    

    public Transform sonarLight;
    public GameObject head;
    public float sonarTime;


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
    private void Start()
    {
        sonarLight.transform.localPosition = head.transform.localPosition;
        sonarLight.gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        controles.Base.LightTrigger.performed += TurnLight;
        controles.Base.Turbo.performed += Turbo;
        controles.Base.ActivateSonar.performed += SonarActivation;
        controles.Enable();

    }
    private void OnDisable()
    {
        controles.Base.LightTrigger.performed -= TurnLight;
        controles.Base.Turbo.performed += Turbo;
        controles.Base.ActivateSonar.performed += SonarActivation;
        controles.Disable();
    }

    void SonarActivation(InputAction.CallbackContext ctx)
    {
        sonarTime = 5.0f;
        sonarLight.transform.localPosition = head.transform.localPosition;
        
        if (ctx.performed&&!lightActive)
        {
            lightActive = true;
            sonarLight.gameObject.SetActive(true);
            StartCoroutine(SonarLightCoroutine());
        }
        
    }

    void TurnLight(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {

            if (LightSystem.IsActive)
            {
                LightSystem.IsActive = false;
            }
            else
                LightSystem.IsActive = true;

            for (int i = 0; i < lights.Length; i++)
            {
                lights[i].enabled = LightSystem.IsActive;
            }
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
        movRef.verticalAcceleration = movRef.verticalAcceleration+turboValue;
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);
        movRef.verticalAcceleration = movRef.verticalAcceleration - turboValue;
        turboActive = false;
        TurboSystem.IsActive = false;
        //After we have waited 5 seconds print the time again.
    }
    IEnumerator SonarLightCoroutine()
    {
        //yield return new WaitForSeconds(5);
        Vector3 startingPos = sonarLight.transform.localPosition;
        Vector3 finalPos = sonarLight.transform.localPosition + (Vector3.up * 15);
        sonarLight.gameObject.SetActive(true);
        float elapsedTime = 0;

        while (elapsedTime < sonarTime)
        {
            sonarLight.transform.localPosition = Vector3.Lerp(startingPos, finalPos, (elapsedTime / sonarTime));
            elapsedTime += Time.deltaTime;
            yield return null;
            
        }
        lightActive = false;
        sonarLight.transform.localPosition = head.transform.localPosition;

    }
}
