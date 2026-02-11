using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Camera cutsceneCam;
    public Camera mainCamera;
    public PlayableDirector cutscene;
    public GameObject panel;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 1f;
    }

    public void StartGame()
    {
        print("Start");
        StartCoroutine(StartGameFlow());
    }

    IEnumerator StartGameFlow()
    {
        Debug.Log("Started");

        // Switch cameras
        mainCamera.gameObject.SetActive(false);
        cutsceneCam.gameObject.SetActive(true);
        panel.gameObject.SetActive(false);


        // Play cutscene
        cutscene.Play();

        // WAIT until it finishes
        while (cutscene.state == PlayState.Playing)
            yield return null;

        Debug.Log("Cutscene ended");

        // Load game scene AFTER cutscene
        SceneManager.LoadScene("Map");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
