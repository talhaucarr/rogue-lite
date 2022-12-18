using System.Collections;
using System.Collections.Generic;
using _Scripts.HealthSystem;
using UnityEngine;

public interface IEntityController
{
    public Transform Transform { get; }
    public IDamagable Damagable { get; }
    void EnemyUpdate();
}
