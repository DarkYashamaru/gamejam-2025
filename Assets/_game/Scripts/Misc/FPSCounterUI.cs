using TMPro;
using UnityEngine;

public class FPSCounterUI : MonoBehaviour
{
    public TextMeshProUGUI text;
    public FPSCounter fpsCounter;

    private void LateUpdate()
    {
        if (fpsCounter == null)
            return;

        text.color = Color.green;

        if (fpsCounter.currentFPS < 60)
            text.color = Color.yellow;

        if (fpsCounter.currentFPS < 30)
            text.color = Color.red;

        text.text = $"FPS {fpsCounter.currentFPSText}";
    }
}
