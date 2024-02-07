using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class singlemole : MonoBehaviour
{
    // Start is called before the first frame update
    public machine_controller machineController;
    public int singlemole_index=1;
    public float downY;
    public float upY;

    [SerializeField] private float upDistanceOffset = 0.5f;
    public bool got_hit_bool = false;
    static bool lostFlag = false;

    public GameObject lefthammer;
    public GameObject righthammer;
    public GameObject mole;

    public bool hitable = false;
    private readonly Color[] colors = { new Color(0.6f, 0.4f, 0.2f), Color.blue, Color.yellow };
    public GameObject moleBody;

    private Color currentColor;


    public static bool start = false;

    [SerializeField]
    public Button startButton;

    [SerializeField] private float speed = .5f; //speed where the moles go up and down
  
    void Start()
    {
        machineController = GameObject.FindObjectOfType<machine_controller>();
        downY = transform.position.y;
        upY = downY + upDistanceOffset;
        ;
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            Move();
        }
    }

    void Move(){
        // move up and doun mechanism, If you want
      
        if (machineController.chosen_mole_array[singlemole_index] ==1 && Mathf.Abs(transform.position.y- upY) > 0.02f && !lostFlag)
        {
            //go up
            transform.Translate(0,Time.deltaTime *speed , 0);
            got_hit_bool = false;
            if (!hitable) {
                hitable = true;
                SetRandomColor();
            }
        }
       
        else if (machineController.chosen_mole_array[singlemole_index] ==0  && Mathf.Abs(transform.position.y-downY) > 0.02f){
            //go down
            currentColor = moleBody.GetComponent<Renderer>().material.color;
            if (!got_hit_bool && currentColor != colors[2])
            {
                if (SceneManager.GetActiveScene().buildIndex == 1)
                lostFlag = true;
                transform.Translate(0, -Time.deltaTime * speed, 0);
                singlemole.start = true;
                startButton.gameObject.SetActive(true);
            }
            else {
                transform.Translate(0, -Time.deltaTime * speed * 2, 0);
            } 
             
            
        }
        else if(lostFlag)
        {
            Lost();
        }
    }

    public void Lost()
    {
        singlemole.start = true;
        startButton.gameObject.SetActive(true);
    }

    private void HandelHit()
    {
        Score.scoreVal += 1;
        got_hit_bool = true;
        machineController.a_mole_got_hit(singlemole_index);
    }

    public void OnCollisionEnter(Collision collision)
    {
        bool collisionEvent = ((collision.gameObject == lefthammer || collision.gameObject == righthammer) || collision.gameObject == mole);

        if (collisionEvent && hitable)
        {
            hitable = false;
            currentColor = moleBody.GetComponent<Renderer>().material.color;
            bool rightHandWithRightColor = (collision.gameObject == lefthammer && currentColor == colors[0]) || (collision.gameObject == righthammer && currentColor == colors[1]);

            if (rightHandWithRightColor)
            {
                HandelHit();
            }
            else
            {
                lostFlag = true;
                singlemole.start = true;
                startButton.gameObject.SetActive(true);
            }

        }
    }

    public void SetRandomColor()
    {
        Renderer renderer = moleBody.GetComponent<Renderer>();
        int randomIndex = Random.Range(0, colors.Length);

        // Set the material's color to the randomly chosen color
        renderer.material.color = colors[randomIndex];
    }
}
