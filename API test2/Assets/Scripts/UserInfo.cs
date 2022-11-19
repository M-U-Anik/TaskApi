using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInfo : MonoBehaviour
{
    public string id;
    //public int id { get; set; }
    public string userName;
    public string userEmail;
    public string userPassword;

    public Text UserNameTxt;
    public Text UserNameTopTxt;
    public Text UserIdTxt;
    public Text UserEmailTxt;

    public GameObject Info;
    public GameObject LoginUI;

    public string token { get; set; }



    

    public void SetCredentials(string useremail, string userpassword)
    {
        userEmail = useremail;
        userPassword = userpassword;
    }

    /* public void SetId(string uId)
     {
         userId = uId;
     }*/
    public void SetToken(string Token)
    {
        token = Token;
    }


}
