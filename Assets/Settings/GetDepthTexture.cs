using UnityEngine;

public class GetDepthTexture : MonoBehaviour
{
    public Camera cam;
    public Material targetMaterial;
    private RenderTexture _depthTexture;
    private RenderTexture _tempTexture;

    private void Start()
    {
        _depthTexture = new RenderTexture(Screen.width, Screen.height, 16, RenderTextureFormat.Depth);
        _tempTexture = new RenderTexture(Screen.width, Screen.height, 16, RenderTextureFormat.Depth);
    }

    private void OnRenderObject()
    {
        if (Camera.current==null || Camera.current.cameraType == CameraType.SceneView || cam == null || targetMaterial == null)
            return;

        // Ensure the camera has a depth texture
        if (!cam.depthTextureMode.HasFlag(DepthTextureMode.Depth))
        {
            cam.depthTextureMode |= DepthTextureMode.Depth;
        }

        var cameraDepthTexture = Shader.GetGlobalTexture("_CameraDepthTexture");

        if (cameraDepthTexture == null)
            return;

        Graphics.Blit(cameraDepthTexture, _depthTexture);

        // Assign the depth texture to the material
        targetMaterial.SetTexture("_DepthTex", _depthTexture);

        // Clean up
        RenderTexture.active = null;
    }

    private void OnDestroy()
    {
        // Release the depth texture
        if (_depthTexture != null)
        {
            _depthTexture.Release();
            _depthTexture = null;
        }
        if (_tempTexture != null)
        {
            _tempTexture.Release();
            _tempTexture = null;
        }
    }
}
