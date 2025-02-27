using System;
using UnityEngine;

/// <summary>
/// Unreal Engine ÀÇ DataTable
/// </summary>

[CreateAssetMenu]
public class TowerDataTable : ScriptableObject
{
    [SerializeField]
    private GameObject towerprefab;
    public GameObject TowerPrefab => towerprefab;
    [SerializeField]
    private TowerDatas[] towerdata;
    public TowerDatas[] TowerData => towerdata;

    [Serializable]
    public struct TowerDatas
    {
        [SerializeField]
        private Sprite sprite;
        public readonly Sprite Sprite => sprite;
        [SerializeField]
        private float damage;
        public readonly float Damage => damage;
        [SerializeField]
        private float rate;
        public readonly float Rate => rate;
        [SerializeField]
        private float range;
        public readonly float Range => range;
        [SerializeField]
        private int cost;
        public readonly int Cost => cost;
    }
}
