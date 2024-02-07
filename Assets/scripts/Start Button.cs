using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartButton : MonoBehaviour
{
    [SerializeField]
    public Button startButton;

    public singlemole singleMole;


    public void buttonPressed()
    {
        singlemole.start = true;
        startButton.gameObject.SetActive(false);
    }
}
