using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class btnClick : MonoBehaviour
{

    private AndroidJavaClass jc;
    private AndroidJavaObject jo;
    private Button btnLogin;
    private Button btnPay;
    private Button btnExitGame;
   

    public void Start()
    {   
        //固定写法
        jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
       
        btnLogin = transform.Find("BtnLogin").GetComponent<Button>(); //登录
        btnPay= transform.Find("BtnPay").GetComponent<Button>();   //支付
        btnExitGame = transform.Find("BtnExit").GetComponent<Button>();   //退出游戏
       
       
        btnLogin.onClick.AddListener(OnBtnLoginClickHandler);
        btnPay.onClick.AddListener(OnBtnPayClickHandler);
        btnExitGame.onClick.AddListener(OnBtnExitGameClickHandler);
    }
  


    /**
      * 登录点击调用
     */
    private void OnBtnLoginClickHandler()
    {
        jo.Call("doLogin");
    }

     private void OnBtnPayClickHandler()
     {
         jo.Call("doPay");
     }

    /**
     * 退出游戏点击调用
     */
    private void OnBtnExitGameClickHandler()
    {
        jo.Call("doExitGame");
       // Application.Quit();//调用C#退出应用
    }
 
    public  void LoginCallback(string msg)
    {
   
        Debug.Log("Login_with_msg : " + msg);
    }

}
