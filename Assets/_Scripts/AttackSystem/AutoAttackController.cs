using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts.AttackSystem;
using _Scripts.StatSystem;
using UnityEngine;

public class AutoAttackController : MonoBehaviour, IAttackController
{
    [SerializeField]
    private AttackBase _attackBase;
    private AttackData _attackData;
    private StatSettings _statSettings;
    private float _attackTimer = 0;
    private float _attackSpeed; // duration = 20 / 3 + attackSpeed

    public void Setup(StatSettings statSettings)
    {
        _statSettings = statSettings;
        _attackData = new AttackData(transform);
        _attackSpeed = statSettings.AttackSpeed;
        _attackBase = Instantiate(_attackBase);
        _attackBase.SetupOrUpdate(statSettings);
    }

    private void FixedUpdate()
    {
        _attackTimer += Time.fixedDeltaTime;
        if (_attackTimer >= (20f / (1 + _attackSpeed)))
        {
            Attack();
        }
    }

    private void Attack()
    {
        if(!_attackBase.Attack(_attackData)) return;
        _attackTimer = 0;
        Debug.Log("Attacked");
    }
}
