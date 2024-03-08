using UnityEngine;

namespace Game.Player
{
    /// <summary>
    /// Input controller. Whatever has this script can change it's position.
    /// With controls, I mean.
    /// </summary>
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(CapsuleCollider2D))]
    public class InputController : MonoBehaviour
    {
        [SerializeField] bool isGrounded = false;
        [SerializeField] bool facingRight = true;

        [Header("Variable References")]
        public VariableReference walkSpeed;
        public VariableReference gravitySpeed;

        //Private stuff
        private Rigidbody2D rb;
        private CapsuleCollider2D col;
        private Transform pos;
        private float direction = 0;

        //Cool stuff
        private bool HasInput => (Input.GetAxis("Horizontal") != 0);
        private bool Grounded => (isGrounded || Mathf.Abs(rb.velocity.x) > 0.01f);
        private float GetInput => Input.GetAxis("Horizontal");
        private bool LowMagnitude => rb.velocity.magnitude < 0.01f;

        private void AssignComponents()
        {
            rb = GetComponent<Rigidbody2D>();
            col = GetComponent<CapsuleCollider2D>();

            pos = transform;
            rb.gravityScale = gravitySpeed.Value;

            rb.freezeRotation = true; //Don't trust the inspector
            facingRight = pos.localScale.x > 0;
        }

        private void Start()
        {
            AssignComponents();
        }

        private void DoMovement()
        {
            if (HasInput && Grounded)
            {
                direction = GetInput;
                return;
            }

            if (isGrounded || LowMagnitude)
                direction = 0;
        }

        private void ChangeDirections()
        {
            if (direction > 0 && !facingRight)
            {
                facingRight = true;
                pos.localScale = new Vector3(Mathf.Abs(pos.localScale.x), pos.localScale.y, transform.localScale.z);
            }

            if (direction < 0 && facingRight)
            {
                facingRight = false;
                pos.localScale = new Vector3(-Mathf.Abs(pos.localScale.x), pos.localScale.y, pos.localScale.z);
            }
        }

        private void Update()
        {
            DoMovement();
            if (direction == 0)
                return;
            ChangeDirections();
        }

        private void CheckColliders()
        {
            Bounds colBounds = col.bounds;
            float colRad = col.size.x * 0.4f * Mathf.Abs(transform.localScale.x);
            Vector3 groundPos = colBounds.min + new Vector3(colBounds.size.x * 0.5f, colRad * 0.9f, 0);

            Collider2D[] cols = Physics2D.OverlapCircleAll(groundPos, colRad);
            isGrounded = false;

            //We check for every collision because why not
            if (cols.Length > 0)
                for (int i = 0; i < cols.Length; i++)
                    if (cols[i] != col)
                    {
                        isGrounded = true;
                        break;
                    }
        }

        void FixedUpdate()
        {
            //Very important (trust)
            CheckColliders();

            //LET'S MOVE THE CHARACTER, HELL YEE
            rb.velocity = new Vector2((direction) * walkSpeed.Value, rb.velocity.y);
        }
    }
}
