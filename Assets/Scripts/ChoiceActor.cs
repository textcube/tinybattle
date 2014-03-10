using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChoiceActor : MonoBehaviour {
    public GameManager gameManager;
    public GameObject[] bulletPrefab;

    Transform[] enemies;
    Animator animator;
    Transform tr;

	void Start () {
        animator = GetComponent<Animator>();
        List<Transform> list = new List<Transform>();
        foreach (Transform tf in GameObject.Find("Enemies").transform)
            list.Add(tf);
        enemies = list.ToArray();
        tr = transform;
	}

    void OnMouseDown()
    {
        gameManager.SendMessage("SetActor", animator, SendMessageOptions.DontRequireReceiver);
    }

    void OnDeal(int type)
    {
        GameObject bPrefab = bulletPrefab[type % 10 - 1];
        Vector3 pos = tr.position + tr.forward * 1.2f + Vector3.up * 1f;
        if (type % 10 == 3)
        {
            Instantiate(bPrefab, tr.position + tr.forward * 1.2f + Vector3.up * 1f, tr.rotation);
            foreach (Transform t in enemies)
                t.SendMessage("OnDamage", SendMessageOptions.DontRequireReceiver);

        }
        Instantiate(bPrefab, tr.position + tr.forward * 1.2f + Vector3.up * 1f, tr.rotation);

    }
	
	void Update () {
	
	}
}
