
using UnityEngine;

public class Chest : Givers ,Interacuable
{
    public ItemObject item;

    protected override void Open()
    {
        anim.SetBool("open",true);
        GiveObject();
    }
    protected override void GiveObject()
    {
        Item _item = new Item(item);
        PM.InvControl.AddItem(_item,1);
    }

    public void interactuar()
    {   Debug.Log("entre");
        Open();
    }
}
