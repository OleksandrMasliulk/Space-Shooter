using UnityEngine;
using Cinemachine;

public class PlayerCameraShake : MonoBehaviour
{
    [SerializeField] private float _impactShakeForce;
    [SerializeField] private float _deathShakeForce;
    
    private CinemachineImpulseSource _impulseSource;

    private void Awake() 
    {
        _impulseSource = GetComponent<CinemachineImpulseSource>();
    }

    public void InvokeImpactShake()
    {
        _impulseSource.GenerateImpulse(_impactShakeForce);
    }

    public  void InvokeDeathShake()
    {
        _impulseSource.GenerateImpulse(_deathShakeForce);
    }
}
