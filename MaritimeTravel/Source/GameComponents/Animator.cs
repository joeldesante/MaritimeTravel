using System;
using System.Collections.Generic;
using System.Text;

namespace MaritimeTravel.Source.GameComponents {
    class Animator {
        private int step;

        struct Keyframe {
            void Execute() { 
            }
        }

        public Animator() {
            step = 0;
        }

        public void StepForward() {
            step++;
        }

        public void StepBackward() {
            if (step <= 0) { return; }
            step--;
        }
    }
}
