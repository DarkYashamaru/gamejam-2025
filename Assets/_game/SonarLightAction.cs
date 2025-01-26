using UnityEngine;
using System.Collections;

public class SonarLightAction : MonoBehaviour
{
    public Transform luz;
    public GameObject head;
    public float time;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        
        //luz.gameObject.SetActive(false);
    }
    private void Start()
    {
        luz = transform;
        luz.transform.localPosition = head.transform.localPosition;
        luz.gameObject.SetActive(false);
    }
    public void StartSonarMoving()
    {
        time = 5.0f;

        luz.transform.localPosition = head.transform.localPosition;
        StartCoroutine(SonarLightCoroutine());
        
    }
    IEnumerator SonarLightCoroutine()
    {
        //yield return new WaitForSeconds(5);
        Vector3 startingPos = transform.position;
        Vector3 finalPos = transform.position - (transform.forward * 15);
        luz.gameObject.SetActive(true);
        float elapsedTime = 0;

        while (elapsedTime < time)
        {
            transform.position = Vector3.Lerp(startingPos, finalPos, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        
    }

}
