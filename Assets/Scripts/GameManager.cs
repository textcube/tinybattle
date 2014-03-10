using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    public Animator[] team;
    public Transform[] hudTeam;
    Animator choice;
    Vector3 hudStartPos;

	void Start () {
        hudStartPos = hudTeam[0].position;
        SetHud(0);
	}

    void SetHud(int who)
    {
        choice = team[who];
        for (int i=0; i<hudTeam.Length; i++) {
            Transform tf = hudTeam[i];
            if (i != who) tf.transform.position = hudStartPos;
            else tf.transform.position = hudStartPos + Vector3.up * 10f;
        }
    }

    void SetActor(Animator ani)
    {
        int i;
        for (i=0; i<team.Length; i++) {
            Animator t = team[i];
            if (t==ani) break;
        }
        if (i >= team.Length) return;
        SetHud(i);
    }

    public void Attack()
    {
        if (!choice) return;
        choice.CrossFade("Attack", 0.2f);
    }

    public void Attack2()
    {
        if (!choice) return;
        choice.CrossFade("Attack2", 0.2f);
    }

    public void Attack3()
    {
        if (!choice) return;
        choice.CrossFade("Attack3", 0.2f);
    }

	void Update () {
	
	}

    public void LoadMenu(){
        Application.LoadLevel("Menu");
    }
}
