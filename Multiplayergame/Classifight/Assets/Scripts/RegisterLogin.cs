using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
public class RegisterLogin : MonoBehaviour
{

    private string baseUrl = "http://localhost:8080/thirteenov/UnityLoginLogoutRegister/";
    [SerializeField] private InputField accountUserName;
    [SerializeField] private InputField accountPassword;
    [SerializeField] private InputField accountConfirmPassword;
    [SerializeField] private Text info;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void AccountRegister()
    {
        string uName = accountUserName.text;
        string pWord = accountPassword.text;
        string cfpword = accountConfirmPassword.text;
        StartCoroutine(RegisterNewAccount(uName, pWord, cfpword));
    }
    public void AccountLogin()
    {
        string uName = accountUserName.text;
        string pWord = accountPassword.text;
        StartCoroutine(LoginAccount(uName, pWord));
    }

    public void RegisterEvent()
    {
        SceneManager.LoadScene("RegisterScenes");
    }
    
    public void LoginEvent()
    {
        SceneManager.LoadScene("LoginScenes");
    }
    IEnumerator RegisterNewAccount(string uName, string pWord, string cfpWord)
    {
        WWWForm form = new WWWForm();
        form.AddField("newAccountUsername", uName);
        form.AddField("newAccountPassword", pWord);
        form.AddField("newAccountConfirmPassword", cfpWord);
        using (UnityWebRequest www = UnityWebRequest.Post(baseUrl, form))
        {
            www.downloadHandler = new DownloadHandlerBuffer();
            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                string responseText = www.downloadHandler.text;
                info.text = responseText;
            }
        }
    }
    IEnumerator LoginAccount(string uName, string pWord)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUsername", uName);
        form.AddField("loginPassword", pWord);
        using (UnityWebRequest www = UnityWebRequest.Post(baseUrl, form))
        {
            www.downloadHandler = new DownloadHandlerBuffer();
            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                string responseText = www.downloadHandler.text;
                SceneManager.LoadScene("MainScenes");
            }
        }
    }
}
