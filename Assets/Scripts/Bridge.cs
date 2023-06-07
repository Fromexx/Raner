using Assets.Scripts.Animations.AnimatorsConstants;
using Assets.Scripts.Army;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        TryGetComponent(out Animator _animator);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Army army))
        {
            _animator.SetTrigger(BridgeAnimationConstants.Params.Up);
        }
    }
}
