using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    public static int scoreVal = 0;
    public static int prevScoreVal = -1;
    TextMesh score;
    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + scoreVal;
    }
}
