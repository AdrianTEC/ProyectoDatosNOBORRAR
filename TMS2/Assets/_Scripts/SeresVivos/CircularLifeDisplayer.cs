using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircularLifeDisplayer : VidaDisplayer{
    public Image bar;
    private float initialSize;

    private void Start(){
        initialSize = bar.fillAmount;
    }

    public override void modifyVisuals(int currentHp, int Maximun){
        bar.fillAmount = (initialSize / Maximun) * currentHp;
    }
}
