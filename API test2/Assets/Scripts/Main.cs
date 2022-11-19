using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public static Main Instance;
    public ApiWeb apiWeb;
    public UserInfo userInfo;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        apiWeb = GetComponent<ApiWeb>();
        userInfo = GetComponent<UserInfo>();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
   
}
