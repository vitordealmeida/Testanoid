using System;
using System.Collections.Generic;
using UnityEngine;

public class BrikController : MonoBehaviour
{
    private GameInteractor _gameInteractor;
    private IBrick brick;
    private Material _material;

    [SerializeField] private BrickType BrickType;
    [SerializeField] private GameObject HitEffectPrefab;

    private static Dictionary<BrickType, Func<IBrick>> brickCreatorMap = new Dictionary<BrickType, Func<IBrick>>
    {
        {BrickType.SIMPLE, () => new SimpleBrick()},
        {BrickType.DOUBLE, () => new DoubleBrick()}
    };

    private void Start()
    {
        _gameInteractor = GameInteractor.Instance;
        brick = brickCreatorMap[BrickType]();
        _material = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        _material.color = brick.Color;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var contactPoint = other.GetContact(0).point;
        Instantiate(HitEffectPrefab, new Vector3(contactPoint.x, contactPoint.y, transform.position.z),
            Quaternion.identity);
        if (brick.TakeHit())
        {
            _gameInteractor.DestroyBrick(brick.Score);
            Destroy(gameObject);
        }
    }
}