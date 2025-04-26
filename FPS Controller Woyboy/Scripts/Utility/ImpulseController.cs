using Unity.Cinemachine;
using UnityEngine;

namespace FPS_Controller_Woyboy
{
    /// <summary>
    ///
    /// ImpulseController is a utility script that holds and controls the properties of
    /// CinemachineImpulseSources. Whether you want to control the shake level of the 
    /// impulse source is all up to you. But for now this script contains one method for
    /// triggering the impulse source.
    /// 
    /// </summary>
    public class ImpulseController : MonoBehaviour
    {
        public CinemachineImpulseSource impulseSource;

        public void Shake()
        {
            impulseSource.GenerateImpulse();
        }
    }

}