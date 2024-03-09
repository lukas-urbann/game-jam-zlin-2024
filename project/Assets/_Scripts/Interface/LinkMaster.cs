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

        private void Start()
        {
            links = GetComponentsInChildren<ILinkable>();

            if (!InitialLink)
            {
                InitialLink = PlayerReference.Instance.Player;
            }

            foreach (ILinkable link in links)
                link.Link(InitialLink);
        }

        public void ChciDomu()
        {
            foreach (ILinkable link in links)
                link.Link(InitialLink);
        }
    }
}
