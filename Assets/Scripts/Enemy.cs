using UnityEngine;

[RequireComponent(typeof(Shooter))]
public class Enemy : MonoBehaviour
{
    private Shooter _shooter;

    private void Awake() 
    {
        _shooter = GetComponent<Shooter>();
    }

    private void Start() 
    {
        _shooter.SetIsIfring(true);
    }
}