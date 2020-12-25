using TMPro;

public class LabelCounterDisplayer : VidaDisplayer
{

    public TextMeshProUGUI texto;
    

    public override void modifyVisuals(int currentHp, int Maximun)
    {
        texto.text = currentHp.ToString();
    }
}
