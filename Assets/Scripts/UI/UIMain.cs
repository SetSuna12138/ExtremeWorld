using Models;
using Services;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMain : MonoSingleton<UIMain>
{

    public Text avatarName;
    public Text avatarLevel;

    // Use this for initialization
    protected override void OnStart()
    {
        this.UpdataAvatar();
    }

    private void UpdataAvatar()
    {
        this.avatarName.text = User.Instance.CurrentCharacter.Name;
        this.avatarLevel.text = User.Instance.CurrentCharacter.Level.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BackToCharSelect()
    {
        SceneManager.Instance.LoadScene("CharSelect");
        UserService.Instance.SendGameLeave();
    }

    public void OnClickUITest()
    {
        UITest test = UIManager.Instance.Show<UITest>();
        test.SetTitle("这是一个测试标题");
        test.OnClose += Test_OnClose;
    }

    private void Test_OnClose(UIWindows sender, UIWindows.WindowsResult result)
    {
        MessageBox.Show("点击了" + result, "对话框响应结果" + MessageBoxType.Information);
    }
    
    public void OnClickBag()
    {
        UIManager.Instance.Show<UIBag>();
    }
}
