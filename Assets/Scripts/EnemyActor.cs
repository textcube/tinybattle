using UnityEngine;
using System.Collections;

public class EnemyActor : MonoBehaviour {
    public GameObject damageEffectPrefab;
    Animator animator;

	void Start () {
        animator = GetComponent<Animator>();
	}

    void OnDeal(int type)
    {
        //Debug.Log("OnDeal : " + type);
    }

	void Update () {
	
	}

    void OnDamage()
    {
        animator.CrossFade("Damage", 0.2f);
        if (damageEffectPrefab) Instantiate(damageEffectPrefab, transform.position + Vector3.up * 1f, Quaternion.identity);
    }

    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            if (contact.otherCollider.tag == "Bullet")
            {
                OnDamage();
            }
        }
    }
}
