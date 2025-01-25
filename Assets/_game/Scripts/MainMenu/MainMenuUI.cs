using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public UIDocument uiDocument;

    void Start()
    {
        SetUIEvents();
    }

    private void SetUIEvents ()
    {
        var root = uiDocument.rootVisualElement;

        var startButton = root.Q<Button>("Start_Game");
        var optionsButton = root.Q<Button>("Options");

        startButton.clicked += OnStartButton;
        optionsButton.clicked += OnOptionsButton;
    }

    private void OnStartButton ()
    {
        Debug.Log("On start game clicked");
        //TODO use a better way to load the scene
        SceneManager.LoadScene(2);
    }

    private void OnOptionsButton ()
    {
        Debug.Log("On Options clicked");
    }
}
