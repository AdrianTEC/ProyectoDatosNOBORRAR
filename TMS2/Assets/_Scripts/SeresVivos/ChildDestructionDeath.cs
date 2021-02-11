using UnityEngine;

namespace _Scripts.SeresVivos{
    public class ChildDestructionDeath : Death
    {
        public GameObject cadaver;
        public GameObject holder;

        public override void act()
        {
            explotar();
        }
        private void explotar()
        {
            Instantiate(cadaver, transform.position, Quaternion.identity);
            holder.GetComponent<ComposedEnemy>().reduceChilds();
            Destroy(transform.parent.gameObject);
        }
    }
}
