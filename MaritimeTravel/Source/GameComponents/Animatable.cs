using System;
using System.Collections.Generic;
using System.Text;

namespace MaritimeTravel.Source.GameComponents {
    class Animatable {
        private int step;

        struct Keyframe {
            void Execute() { 
            }
        }

        public Animatable() {
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
