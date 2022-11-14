using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.GameCore.Player
{
    public class PlayerVFXController : MonoBehaviour
    {
        [SerializeField] private Transform _VFXParent;
        [SerializeField] private List<GameObject> _VFXList;
        
        public void AddVFX(GameObject vfx)
        {
            _VFXList.Add(vfx);
        }
        
        public void RemoveVFX(GameObject vfx)
        {
            _VFXList.Remove(vfx);
        }
        
        public void CreateVFX(GameObject vfx)
        {
            var playerTransform = PlayerManager.Instance.transform;
            var vfxInstance = Instantiate(vfx, playerTransform.position, playerTransform.rotation);
            vfxInstance.transform.parent = _VFXParent;
            AddVFX(vfxInstance);
        }
    }
}
