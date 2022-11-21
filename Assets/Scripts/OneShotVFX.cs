using UnityEngine;

[RequireComponent(typeof(Animator))]
public class OneShotVFX : MonoBehaviour
{
    private Animator _animator;

    private void Awake() 
    {
        _animator = GetComponent<Animator>();
    }

    private void Start() 
    {
        DestroyItself();
    }

    private void DestroyItself()
    {
        float destroyDelay = _animator.GetCurrentAnimatorStateInfo(0).length;
        Destroy(this.gameObject, destroyDelay);
    }
}