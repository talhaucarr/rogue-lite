using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEntityController
{
    public Transform Transform { get; }
    void EnemyUpdate();
}
