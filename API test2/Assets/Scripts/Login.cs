using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public InputField EmailInput;
    public InputField PasswordInput;
    public Button LoginBtn;

    

    // Start is called before the first frame update
    void Start()
    {
        LoginBtn.onClick.AddListener(() =>
        {
           StartCoroutine(Main.Instance.apiWeb.Login(EmailInput.text, PasswordInput.text));
            
        });
    }

}
