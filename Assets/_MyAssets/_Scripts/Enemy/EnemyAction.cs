using UnityEngine;

public class EnemyAction : MonoBehaviour
{
    // private EnemyManager _enemyManager;

    [SerializeField] private Animator _animator;
    public Animator Anim => _animator;


    void Start()
    {
        // _enemyManager = this.GetComponentInParent<EnemyManager>();    
    }

    public void SetWalk(bool value = true)
    {
        Anim.SetBool("walk", value);
    }

    public void SetDeath(bool value = true)
    {
        Anim.SetBool("death", value);
    }

    public void SetAttack()
    {
        Anim.SetTrigger("attack");
    }

}