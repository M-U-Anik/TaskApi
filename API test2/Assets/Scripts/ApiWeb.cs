using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class ApiWeb : MonoBehaviour
{
    public string baseUri = @"https://test.ludocorner.xyz/api/";
    void Start()
    {
        //StartCoroutine(Login("test.user@gmail.com", "12345678"));
    }
    public void ShowUserItems()
    {
        StartCoroutine(GetItemsIds(Main.Instance.userInfo.token));      
    }
    public class Udetails
    {
        public string type;
        public Data data;
    }
    public class Data
    {
        public string id;
        public string name;
        public string email;
        public string token;
    }
    public IEnumerator Login(string email, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("email", email);
        form.AddField("password", password);

        using (UnityWebRequest www = UnityWebRequest.Post(baseUri+"login", form))
        {
            yield return www.SendWebRequest();
            
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                Main.Instance.userInfo.SetCredentials(email, password);            
                Udetails getToken = JsonConvert.DeserializeObject<Udetails>(www.downloadHandler.text);
                Main.Instance.userInfo.Info.SetActive(true);
                Main.Instance.userInfo.LoginUI.SetActive(false);
                Debug.Log(getToken.data.id);
                Main.Instance.userInfo.SetToken(getToken.data.token);
                Debug.Log(Main.Instance.userInfo.token);
                Main.Instance.userInfo.UserNameTxt.text = getToken.data.name;
                Main.Instance.userInfo.UserNameTopTxt.text = getToken.data.name;
                Main.Instance.userInfo.UserIdTxt.text = getToken.data.id;
                Main.Instance.userInfo.UserEmailTxt.text = getToken.data.email;
            }
        }
    }
    IEnumerator GetItemsIds(string TToken)
    {
        WWWForm form = new WWWForm();
        //form.AddField("token", TToken);
        /*form.AddField("email", email);
        form.AddField("password", password);*/
        form.headers.Add("Athorization", "Bearer"+ TToken);
        using (UnityWebRequest www = UnityWebRequest.Post(baseUri + "product/view_product",form))
        {
            //www.SetRequestHeader("Athorization", TToken);
            yield return www.SendWebRequest();
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                string jsonArray = www.downloadHandler.text;
            }
        }
    }

     /*IEnumerator GetItemsIds(string TToken)
    {
        WWWForm form = new WWWForm();
        //form.AddField("token", TToken);
        *//*form.AddField("email", email);
        form.AddField("password", password);*//*
        form.headers.Add("Athorization", "bearer" + TToken);

        using (UnityWebRequest www = UnityWebRequest.Post(baseUri+"product/view_product",form))
        {
            yield return www.Send();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                string jsonArray = www.downloadHandler.text;
            }
        }
    }*/

}
