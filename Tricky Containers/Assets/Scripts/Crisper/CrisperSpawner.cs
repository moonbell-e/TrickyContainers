using System.Collections.Generic;
using UnityEngine;
using System;

public class CrisperSpawner : MonoBehaviour
{
    public static event Action<CrisperEntity> CrisperSpawnEvent;

    [SerializeField] private List<GameObject> _crisperPrefabs;
    [SerializeField] private List<Transform> _points;
    [SerializeField] private CrisperEntity _crisperEntity;

    private void Start()
    {
        SpawnRandomPrefab();
    }
    private void SpawnRandomPrefab()
    {
        int randomPrefabIndex = UnityEngine.Random.Range(0, _crisperPrefabs.Count);
        int randomPointIndex = UnityEngine.Random.Range(0, _points.Count);
        Instantiate(_crisperPrefabs[randomPrefabIndex], _points[randomPointIndex]);
        _crisperEntity = _points[randomPointIndex].GetChild(0).GetComponent<CrisperEntity>();
        SendCrisperEntity(_crisperEntity);
    }

    private void SendCrisperEntity(CrisperEntity crisperEntity)
    {
        CrisperSpawnEvent?.Invoke(crisperEntity);
    }
}
