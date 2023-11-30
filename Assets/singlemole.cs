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

    

    [SerializeField] private float speed = 2.0f;
  
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
         if (machineController.chosen_mole_array[singlemole_index] ==1 && Mathf.Abs(transform.position.y- upY) > 0.02f){
            //go up
            transform.Translate(0,Time.deltaTime *speed , 0);

        }
       
        else if (machineController.chosen_mole_array[singlemole_index] ==0  && Mathf.Abs(transform.position.y-downY) > 0.02f){
            //go down
            transform.Translate(0,-Time.deltaTime *speed , 0);

        }
   
    }
    
   
}
