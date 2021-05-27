using UnityEngine;

namespace Claw.Processes {
    public interface IProcess {

        void Run(MonoBehaviour runner);
    }
}