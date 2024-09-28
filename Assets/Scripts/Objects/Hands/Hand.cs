using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField]
    private List<FingerNail> state;
    private bool win;
    private int counter;
    //used by winlose script
    public bool Win{
        get { return win; }
    }
    // Start is called before the first frame update
    void Start()
    {
        win = false;
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(!win){
            CheckSuccess();
        }
    }

    private void CheckSuccess(){
        for(int i = 0; i < 5; i++){
            if(state[i].IsPainted){
                counter++;
            }
        }
        if(counter == 5){
            win = true;
        }else{
            win = false;
        }
    }
}
