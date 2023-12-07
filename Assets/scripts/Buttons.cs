using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Buttons : MonoBehaviour
{
    public Text buttonText;
    // Start is called before the first frame update
    public void play()
    {
        SceneManager.LoadScene(1);
    }
    public void tryAgain()
    {
        SceneManager.LoadScene(1);
        Score.scoreVal = 0;
        Score.prevScoreVal = -1;
    }
}
