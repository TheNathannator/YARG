using System.Collections.Generic;
using System.Linq;
using UnityEngine.InputSystem;
using YARG.Core;

namespace YARG.Input
{
    public class ProfileBindings
    {
        public YargProfile Profile { get; }

        private Dictionary<InputDevice, DeviceBindings> _deviceBindings;

        public ProfileBindings(YargProfile profile)
        {
            Profile = profile;
        }

        public bool AddDevice(InputDevice device)
        {
            if (_deviceBindings.ContainsKey(device))
            {
                return false;
            }

            _deviceBindings.Add(device, new(device));
            return true;
        }

        public bool ContainsDevice(InputDevice device)
        {
            return _deviceBindings.ContainsKey(device);
        }

        public DeviceBindings TryGetBindsForDevice(InputDevice device)
        {
            return _deviceBindings.TryGetValue(device, out var bindings) ? bindings : null;
        }

        public bool RemoveDevice(InputDevice device)
        {
            return _deviceBindings.Remove(device);
        }
    }
}