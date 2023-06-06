using Animations;
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
            _animator.SetTrigger(BridgeController.Params.Up);
        }
    }
}
