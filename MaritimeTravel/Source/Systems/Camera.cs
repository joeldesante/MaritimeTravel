using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaritimeTravel.Source.Systems {
    class Camera {
        public Vector2 Offset { get; set; }

        public Camera() {
            this.Offset = new Vector2(0, 0);
        }
    }
}
