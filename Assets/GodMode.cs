using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GodMode : MonoBehaviour
{
    [SerializeField] AudioManager audioManager;
    public bool godmode = false;
    public TMP_Text godmodeText;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "GodMode";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("g"))
        {
            audioManager.GodModeAudio();
            godmode = !godmode;
            Debug.Log("godmode on");
        }
        if (godmode)
        {
            godmodeText.text = "God Mode active!";
        }
        else
        {
            godmodeText.text = "";
        }
    }

    /*public void DisplayText()
    {
        godmodeText.text = "God Mode active!";
        //https://discussions.unity.com/t/how-do-i-make-text-appear-when-i-click-a-button/165534/2
    }*/
}
