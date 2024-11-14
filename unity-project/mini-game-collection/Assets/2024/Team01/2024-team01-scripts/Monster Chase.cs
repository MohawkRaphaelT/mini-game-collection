using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterChase : MonoBehaviour
{
    public GameObject Monsters;
    public GameObject Target;
    public float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Monsters.transform.position = Vector3.MoveTowards(Monsters.transform.position, Target.transform.position, speed);
    }
}
