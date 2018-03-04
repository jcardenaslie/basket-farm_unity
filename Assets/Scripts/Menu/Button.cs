using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectLevel : MonoBehaviour {


    public Color defaultColour;
    public Color selecteColour;
    private Material mat;

    void Start(){
        mat = GetComponent<Renderer>().material;
    }

    void OnTouchDown() {
        Debug.Log("Change Color");
        mat.color = selecteColour;
    }

    //void OnTouchUp() {
    //    mat.color = defaultColour;
    //}

    //void OnTouchStay() {
    //    mat.color = selecteColour;
    //}

    void OnTouchExit() {
        mat.color = defaultColour;
    }
}
