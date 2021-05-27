using System.Collections;
using UnityEngine;

namespace Claw.Processes {
    public abstract class Process {

        private Coroutine coroutine;

        private MonoBehaviour runner;
		
        public void Run(MonoBehaviour runner) {

            this.runner = runner;

            coroutine = runner.StartCoroutine(DoRun());
        }

        public void Stop() {
			
            runner.StopCoroutine(coroutine);
        }
		
        protected abstract IEnumerator DoRun();
    }
}