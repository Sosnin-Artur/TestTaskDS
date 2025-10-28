using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

namespace Animals.Components.Movement
{
    public class JumpMoveComponent : MoveComponent
    {
        [SerializeField]
        private float _jumpTime = 3f;
        [SerializeField]
        private float _jumpDistance = 3;
        [SerializeField]
        private float _jumpHeight = 3f;

        private Vector3 _jumpVelocity;
        private CancellationTokenSource _cancellationTokenSource;

        public void Awake()
        {
            _jumpVelocity = CalculateJumpVelocity();
            _cancellationTokenSource = new();
        }

        public override void Move(float speed, Vector3 direction)
        {
            var jumpVel = transform.rotation * _jumpVelocity;
            Rigidbody.AddForce(jumpVel, ForceMode.VelocityChange);

            StartTimerAsync(_cancellationTokenSource.Token);
        }

        private void OnDestroy()
        {
            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource?.Dispose();
        }

        private async UniTaskVoid StartTimerAsync(CancellationToken cancellationToken)
        {
            await UniTask.Delay((int)(_jumpTime * 1000f), true, PlayerLoopTiming.Update, cancellationToken);
            Move(_jumpDistance, _jumpVelocity);
        }

        private Vector3 CalculateJumpVelocity()
        {
            var g = Mathf.Abs(Physics.gravity.y);
            var th = Mathf.Sqrt(2 * _jumpHeight / g);
            var vv = g * th / 2;
            var vh = _jumpDistance / (2 * th);

            return new Vector3(0, vv, vh);
        }
    }
}