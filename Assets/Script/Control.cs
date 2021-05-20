using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public int Col,Row;
    public int KeyC,KeyR;
    public bool ans;

    private void OnMouseDown() {
        var holo=GameObject.FindWithTag("holo");
        if(Row==holo.GetComponent<Control>().Row&&(Mathf.Abs(Col-holo.GetComponent<Control>().Col)==1)
        ||Col==holo.GetComponent<Control>().Col&&(Mathf.Abs(Row-holo.GetComponent<Control>().Row)==1))
        changePosition(holo);   
    }
    private void changePosition(GameObject holo)
    {
        var holoPosition=holo.transform.position;
        holo.transform.position=this.transform.position;
        this.transform.position=holoPosition;
        var Row=holo.GetComponent<Control>().Row;
        var Col=holo.GetComponent<Control>().Col;
        holo.GetComponent<Control>().Row=this.Row;
        holo.GetComponent<Control>().Col=this.Col;
        this.Row=Row;
        this.Col=Col;
        GameObject.FindWithTag("Player").GetComponent<gamemanage>().TouchTime++;
    }
    private void Update()
    {
        if(KeyC==Col&&KeyR==Row)
            ans=true;
        else
            ans=false;
    }
}   
