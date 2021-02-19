using System;
using UnityEngine;
namespace _Scripts._Generales{
    public interface ComposedCollider{
        public void tellAboutCollision(Collider col);
        public void tellAboutCollision(Collision col);
    }
}