using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class machine_controller : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float default_up_down_time = 2.0f ;
    [SerializeField] private float up_down_timer;

    [SerializeField] private float maxNumberOfMoles = 3;
    private bool active = false;
    
    public int[] chosen_mole_array = {0,0,0,0,0,0,0,0,0};
    void Start()
    {
        up_down_timer = default_up_down_time;
    }

    // Update is called once per frame
    void Update()
    {
        up_down_timer -= Time.deltaTime;
        
        if (up_down_timer <= 0.0f)
        { //timer is up
            up_down_timer = 2.0f;
            timerEnded();
        }
        
    }
    void AddOnesWithProbability()
    {
        System.Random random = new System.Random();
        int ones_count = 0;
        for (int i = 0; i < chosen_mole_array.Length; i++)
        {
            double probability = random.NextDouble(); // generates a random number between 0.0 and 1.0

            if (probability <= 0.3 ){
                chosen_mole_array[i] = 1;
                ones_count ++;
            }
            if (ones_count >= maxNumberOfMoles){
                break;
            }
            
            }

        if (ones_count == 0){
            chosen_mole_array[random.Next(0, 10)] = 1;
        }

    }

    
    
    void timerEnded()
    {
            // if it was active-> reset the moles to zero
            // if it was not active -> addOnes to the array
            //chose_a_mole

            if (active){
                for (int i =0; i<9;i++){
                    chosen_mole_array[i] = 0;
                    active = false;
                }
            }
            else{
                AddOnesWithProbability();
                active = true;
            }
    }
    public void a_mole_got_hit(int index){
        chosen_mole_array[index] = 0;   
    }
}
