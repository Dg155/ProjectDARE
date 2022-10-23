using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class TextBox : MonoBehaviour
{

    TextMeshProUGUI TM;
    SceneLoader SL;
    public const string kalphaCode = "<color=#00000000>";
    public int characterPopupDelay = 50;
    private bool finishedText;
    [SerializeField] ButtonScript BS;
    [SerializeField] string firstMessage;
    [SerializeField] string secondMessage;
    [SerializeField] string thirdMessage;
    [SerializeField] string fourthMessage;
    [SerializeField] string fithMessage;
    [SerializeField] string sixthMessage;
    [SerializeField] string lastMessage;

    void Start()
    {
        finishedText = true;
        TM = GetComponentInChildren<TextMeshProUGUI>();
        SL = (SceneLoader)FindObjectOfType(typeof(SceneLoader));
        startMessages();
    }

    private async void startMessages()
    {
        await Task.Delay(80);
        popUp(firstMessage);
        popUp(secondMessage);
        popUp(thirdMessage);
        popUp(fourthMessage);
        popUp(fithMessage);
        popUp(sixthMessage);
        popUp(lastMessage);
    }

    public async void popUp(string message)
    {
        while (!BS.readyToStart()) {await Task.Yield();}
        while (!finishedText) {await Task.Yield();}
        finishedText = false;
        gameObject.SetActive(true);
        await DisplayText(message);
        await waitForKeyPress(KeyCode.Mouse0);
        if (message == lastMessage) { SL.LoadNextScene();}
        gameObject.SetActive(false);
        finishedText = true;       
    }

    private async Task DisplayText(string message)
    {
        TM.text = "";
        string displayText = "";
        int alphaIndex = 0;

        foreach(char c in message.ToCharArray())
        {
            alphaIndex++;
            TM.text = message;
            displayText = TM.text.Insert(alphaIndex, kalphaCode);
            TM.text = displayText;
            await Task.Delay(characterPopupDelay);
        }
        return;
    }

    private async Task waitForKeyPress(KeyCode key)
    {
        bool done = false;
        while(!done) // essentially a "while true", but with a bool to break out naturally
        {
            if(Input.GetKeyDown(key))
            {
                done = true; // breaks the loop
            }
            await Task.Yield(); // wait until next frame, then continue execution from here (loop continues)
        }
        return;
        // now this function returns
    }
}
