using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _reward;
    
    private Player _target;

    public event UnityAction<Enemy> Dying;

    public int Reward => _reward;
    public Player Target => _target;
    
    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Dying?.Invoke(this);
            Destroy(gameObject);
        }            
    }

    public void Init(Player target)
    {
        _target = target;
    }
}