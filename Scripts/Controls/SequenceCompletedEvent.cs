
using Claw.Events;

namespace Claw.Controls {
    public class SequenceCompletedEvent : GameEvent {

        private readonly string seqName;

        public string SeqName => seqName;

        public SequenceCompletedEvent(string seqName) {
            this.seqName = seqName;
        }
    }
}