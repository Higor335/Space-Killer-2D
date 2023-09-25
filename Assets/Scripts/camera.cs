using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour{

    

    // Start is called before the first frame update
    void Start(){
                Screen.SetResolution(1308, 669, true);
    }

    // Update is called once per frame
    void Update(){
        transform.position += new Vector3(5f * Time.deltaTime, 0, 0);
        
    }
}