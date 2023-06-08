using Assets.Scripts.Animations.AnimatorsConstants;
using Assets.Scripts.Unit;
using UnityEngine;

public class BridgeButton : MonoBehaviour
{
    private Animator bridgeAnimator;
    private Animator buttonAnimator;

    private void Awake()
    {
        bridgeAnimator = GetComponentInParent<Animator>();
        TryGetComponent(out Animator buttonAnimator);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Unit unit))
        {
            bridgeAnimator.SetTrigger(BridgeAnimationConstants.Params.Up);
        }
    }
}
