using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenuUI : MonoBehaviour
{
    public UIDocument uiDocument;

    IEnumerator Start()
    {
        yield return null;
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
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

    private void OnOptionsButton ()
    {
        Debug.Log("On Options clicked");
    }
}
