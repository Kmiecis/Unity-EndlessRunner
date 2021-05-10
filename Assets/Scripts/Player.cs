using Common;
using UnityEngine;

namespace Game
{
    public class Player : MonoBehaviour
    {
        enum EPlayerState
        {
            Running,
            Jumping,
            Falling
        }

        private readonly int RUNNING_ANIMATOR_ID = Animator.StringToHash("Running");
        private readonly int JUMPING_ANIMATOR_ID = Animator.StringToHash("Jumping");
        private readonly int FALLING_ANIMATOR_ID = Animator.StringToHash("Falling");

        [Dependant]
        private SpeedController m_SpeedController;

        [Dependant]
        private InputController m_InputController;

        [SerializeField] protected Rigidbody2D m_Rigidbody;
        [SerializeField] protected Animator m_Animator;

        [Space(10)]
        public float jumpForce = 10.0f;
        public float jumpBoost = 20.0f;
        public int jumpsLimit = 2;
        public float offsetVelocity = 2.0f;
        public bool canDestroy = false;

        [SerializeField] [ReadOnlyField] protected bool m_IsAlive = true;
        [SerializeField] [ReadOnlyField] protected int m_JumpsUsed = 0;
        [SerializeField] [ReadOnlyField] protected float m_SnareReleaseTime = 0.0f;
        [SerializeField] [ReadOnlyField] private EPlayerState m_PlayerState = EPlayerState.Running;
        private EPlayerState m_AnimatorState = EPlayerState.Running;

        public bool IsAlive => m_IsAlive;
        public bool IsSnared => m_SnareReleaseTime >= Time.time;
        public bool IsOffset => transform.position.x < 0.0f;
        public bool HasJumps => m_JumpsUsed < jumpsLimit;
        public bool CanJump => IsAlive && HasJumps && !IsSnared;
        public bool IsRunning => m_PlayerState == EPlayerState.Running;
        public bool IsJumping => m_PlayerState == EPlayerState.Jumping;
        public bool IsFalling => m_PlayerState == EPlayerState.Falling;
        public bool IsAscending => m_Rigidbody.velocity.y > 0.0f;
        public bool IsDescending => m_Rigidbody.velocity.y < 0.0f;

        private void SetHorizontalVelocity(float f)
        {
            var velocity = m_Rigidbody.velocity;
            velocity.x = f;
            m_Rigidbody.velocity = velocity;
        }

        private void SetVerticalVelocity(float f)
        {
            var velocity = m_Rigidbody.velocity;
            velocity.y = f;
            m_Rigidbody.velocity = velocity;
        }

        public void SetSnared(float duration)
        {
            m_SnareReleaseTime = Time.time + duration;

            if (IsAscending)
                SetVerticalVelocity(0.0f);
        }

        public float GetHorizontalVelocity()
        {
            if (IsSnared)
                return -m_SpeedController.CurrentSpeed;
            if (IsOffset)
                return offsetVelocity;
            return 0.0f;
        }

        private void TryJump()
        {
            if (CanJump)
            {
                m_JumpsUsed++;

                m_Rigidbody.velocity = Vector2.zero;
                m_Rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

                m_PlayerState = EPlayerState.Jumping;
            }
        }

        private void TryJumpBoost()
        {
            if (IsJumping && IsAscending)
            {
                m_Rigidbody.AddForce(Vector2.up * jumpBoost * Time.deltaTime, ForceMode2D.Impulse);
            }
        }

        public void Kill()
        {
            m_IsAlive = false;

            gameObject.SetActive(false);
        }

        public void Revive()
        {
            m_IsAlive = true;

            gameObject.SetActive(true);
        }

        private void UpdateVelocity()
        {
            var currentHorizontalVelocity = GetHorizontalVelocity();
            SetHorizontalVelocity(currentHorizontalVelocity);
        }

        private void UpdateJumping()
        {
            if (IsJumping && IsDescending)
            {
                m_PlayerState = EPlayerState.Falling;
            }
        }

        private void UpdateAnimator()
        {
            if (m_AnimatorState != m_PlayerState)
            {
                m_Animator.SetTrigger(RUNNING_ANIMATOR_ID, IsRunning);
                m_Animator.SetTrigger(JUMPING_ANIMATOR_ID, IsJumping);
                m_Animator.SetTrigger(FALLING_ANIMATOR_ID, IsFalling);

                m_AnimatorState = m_PlayerState;
            }
        }

        private void Awake()
        {
            Dependencies.Bind(this);
        }

        private void Start()
        {
            m_InputController.OnMainActionDown += TryJump;
            m_InputController.OnMainAction += TryJumpBoost;
        }

        private void Update()
        {
            UpdateVelocity();
            UpdateJumping();
            UpdateAnimator();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            var contactCount = collision.contactCount;
            for (int i = 0; i < contactCount; i++)
            {
                var contact = collision.GetContact(i);
                if (contact.point.y < transform.position.y)
                {
                    m_PlayerState = EPlayerState.Running;
                    m_JumpsUsed = 0;

                    break;
                }
            }
        }
    }
}