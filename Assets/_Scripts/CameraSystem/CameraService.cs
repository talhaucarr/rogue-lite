using UnityEngine;

namespace _Scripts.CameraSystem
{
    public class CameraService : Service<CameraService>
    {
        [SerializeField] private Camera mainCamera;
        public Camera Camera => mainCamera;

        internal override void Init()
        {
        }

        internal override void Begin()
        {
            SetReady();
        }

        internal override void Dispose()
        {
        }
    }
}
