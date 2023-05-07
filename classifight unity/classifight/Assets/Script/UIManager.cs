using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject startMenu;
    public InputField usernameFile;
    public GameObject start;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
        else if (instance != this) {
            Debug.Log("Instance already exists, destroying object!");
            Destroy(this);
        }
    }
    public void ConnectToServer() {
        //startMenu.SetActive(false);
        //usernameFile.interactable = false;
        start.SetActive(false);
        Client.instance.ConnectToServer();
    }
}
