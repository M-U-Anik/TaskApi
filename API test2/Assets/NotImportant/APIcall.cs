using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.Networking;
using TMPro;
using UnityEngine.SceneManagement;


public class APIcall : MonoBehaviour
{
    public class Fact
    {
        public string fact { get; set; }
        public int length { get; set; }
    }

    public TextMeshProUGUI text;

    private void Start()
    {
        StartCoroutine(GetRequest("https://catfact.ninja/fact"));
    }

    public void Refresh()
    {
        Start();
    }

    IEnumerator GetRequest(string ureq)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(ureq))
        {
            yield return webRequest.SendWebRequest();

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(string.Format("Something went wrong: {0}", webRequest.error));
                    text.text = (string.Format("!!! Something went wrong: {0}", webRequest.error).ToString());
                    break;
                case UnityWebRequest.Result.Success:
                    Fact fact = JsonConvert.DeserializeObject<Fact>(webRequest.downloadHandler.text);
                    text.text = fact.fact;
                    break;
            }
        }
        
    }

    public void Load1() 
    {
        SceneManager.LoadScene(0);
    }
    public void Load2() 
    {
        SceneManager.LoadScene(1);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
