using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableMonster : Unit
{   [SerializeField]
    private float speed = 2.5F;

    private Bullet bullet;
    private Vector3 direction;



    private SpriteRenderer sprite;

    protected override void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    protected override void Start()
    {
        direction = transform.right;
    }

    protected override void Update()
    {
        
    }

}
