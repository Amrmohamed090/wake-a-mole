using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hammer : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 mousePos;
    Camera m_MainCamera;

    void Start()
    {
        m_MainCamera = Camera.main;
        HideCursor();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;
        
        mousePos.z = -m_MainCamera.transform.position.z;
        transform.position = m_MainCamera.ScreenToWorldPoint(mousePos);

        if(Input.GetMouseButtonDown(0) && SceneManager.GetActiveScene().buildIndex == 1)
        {
            Score.prevScoreVal += 1;

        }



        if (Score.scoreVal <= Score.prevScoreVal)
        {
            lost();
        }
    }

    void HideCursor()
    {
        Cursor.visible = false;
    }

    void showCursor()
    {
        Cursor.visible = true;
    }
    void lost()
    {
        showCursor();
        SceneManager.LoadScene(2);
    }
}
