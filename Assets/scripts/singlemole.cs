using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class singlemole : MonoBehaviour
{
    // Start is called before the first frame update
    public machine_controller machineController;
    public int singlemole_index=1;
    public float downY;
    public float upY;
    public bool got_hit_bool = false;
    public bool lostFlag = false;



    [SerializeField] private float speed = 2.0f; //speed where the moles go up and down
  
    void Start()
    {
        machineController = GameObject.FindObjectOfType<machine_controller>();
        downY = transform.position.y;
        upY = downY + 1.4f;
        ;
    }

    // Update is called once per frame
    void Update()
    {
        Move();

 
    }

    void Move(){
        // move up and doun mechanism, If you want
      
        if (machineController.chosen_mole_array[singlemole_index] ==1 && Mathf.Abs(transform.position.y- upY) > 0.02f && !lostFlag)
        {
            //go up
            
            transform.Translate(0,Time.deltaTime *speed , 0);
            got_hit_bool = false;
            
            
        }
       
        else if (machineController.chosen_mole_array[singlemole_index] ==0  && Mathf.Abs(transform.position.y-downY) > 0.02f){
            //go down

            if (!got_hit_bool)
            {
                if (SceneManager.GetActiveScene().buildIndex == 1)
                    lostFlag = true;
                transform.Translate(0, -Time.deltaTime * speed, 0);
                
            }
            else {
                transform.Translate(0, -Time.deltaTime * speed * 2, 0);
            } 
             
            
        }
        else if(lostFlag)
        {
            lost();
        }
    }
    void OnMouseDown(){

        //here you can track the hitted mole
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            print(singlemole_index);
            machineController.a_mole_got_hit(singlemole_index);
            got_hit_bool = true;
            Score.scoreVal += 1;

        }
    }

    void showCursor()
    {
        Cursor.visible = true;
    }
    public void lost()
    {
        showCursor();
        lostFlag = false;
        // Handling the lost condition
    }
}
