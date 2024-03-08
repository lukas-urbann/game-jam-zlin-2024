using UnityEngine;

namespace Game
{
    /// <summary>
    /// Use to connect child objects with the root parent.
    /// </summary>
    public interface ILinkable
    {
        public void Link(GameObject linkedObject) => SaveLinkReference(linkedObject);
        public void SaveLinkReference(GameObject masterObject);
    }
}
