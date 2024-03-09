using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    /// <summary>
    /// Use to link objects with other object's children.
    /// </summary>
    public class LinkMaster : MonoBehaviour
    {
        public GameObject InitialLink;
        private ILinkable[] links;
        public bool LinkWithPlayerReferenceInstead = false;

        private void OnEnable()
        {
            links = GetComponentsInChildren<ILinkable>();

            if (!InitialLink)
            {
                InitialLink = this.gameObject;

                if (LinkWithPlayerReferenceInstead)
                    InitialLink = PlayerReference.Instance.Player;
            }

            foreach (ILinkable link in links)
                link.Link(InitialLink);
        }
    }
}
