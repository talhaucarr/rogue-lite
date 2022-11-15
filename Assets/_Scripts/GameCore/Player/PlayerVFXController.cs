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
        
        public void CreateVFX(GameObject vfx, bool isAura = false)
        {
            var playerTransform = PlayerManager.Instance.transform;
            var vfxInstance = Instantiate(vfx, playerTransform.position, playerTransform.rotation);
            if (isAura)
            {
                vfxInstance.transform.SetParent(_VFXParent);
                vfxInstance.transform.localPosition = Vector3.zero;
            }
            else
            {
                vfxInstance.transform.position = transform.position;
            }
            
            vfxInstance.SetActive(true);
            AddVFX(vfxInstance);
        }
    }
}
