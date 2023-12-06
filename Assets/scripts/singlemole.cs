using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class singlemole : MonoBehaviour
{
    // Start is called before the first frame update
    public machine_controller machineController;
    public int singlemole_index=1;
    public float downY;
    public float upY;
    public bool got_hit_bool = false;
    

    [SerializeField] private float speed = 2.0f; //speed where the moles go up and down
  
    void Start()
    {
        machineController = GameObject.FindObjectOfType<machine_controller>();
        downY = transform.position.y;
        upY = downY + 1.4f;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        
        
      
        
       
    }

    void Move(){
        // move up and doun mechanism, If you want
         if (machineController.chosen_mole_array[singlemole_index] ==1 && Mathf.Abs(transform.position.y- upY) > 0.02f){
            //go up
            
            transform.Translate(0,Time.deltaTime *speed , 0);
            got_hit_bool = false;
        }
       
        else if (machineController.chosen_mole_array[singlemole_index] ==0  && Mathf.Abs(transform.position.y-downY) > 0.02f){
            //go down

            if (!got_hit_bool)
            transform.Translate(0,-Time.deltaTime *speed , 0);
            else transform.Translate(0,-Time.deltaTime *speed*2 , 0);
            
        }
   
    }
    void OnMouseDown(){

        //here you can track the hitted mole
        print(singlemole_index);
        machineController.a_mole_got_hit(singlemole_index);
        got_hit_bool = true;
    }
    
   
}
