using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{

    [SerializeField] private GameObject cutSceneCanvas;
    private bool startText;

    private void Start() {
        startText = false;
        cutSceneCanvas.SetActive(false);
    }

    public void startButtonClicked(){
        cutSceneCanvas.SetActive(true);
        transform.parent.gameObject.SetActive(false);
        startText = true;
    }

    public bool readyToStart(){
        return startText;
    }
}
