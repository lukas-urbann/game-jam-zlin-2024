using UnityEngine;

namespace Game
{
    /// <summary>
    /// Use to link objects with other object's children.
    /// </summary>
    public class LinkMaster : MonoBehaviour
    {
        public GameObject InitialLink;
        private ILinkable[] links;

        private void OnEnable()
        {
            links = GetComponentsInChildren<ILinkable>();

            if (!InitialLink)
                InitialLink = this.gameObject;

            foreach (ILinkable link in links)
                link.Link(InitialLink);
        }
    }
}
