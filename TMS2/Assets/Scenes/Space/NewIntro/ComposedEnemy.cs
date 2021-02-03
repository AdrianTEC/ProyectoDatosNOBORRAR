using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComposedEnemy : MonoBehaviour{

    public int childs;
    public Death death;
    void verify(){
        if(childs<=0)
            death.act();
    }

    public void reduceChilds(){
        childs--;
        verify();
    }
}
