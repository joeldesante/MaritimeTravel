using MaritimeTravel.Source.GameComponents;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaritimeTravel.Source.Systems {
    class Camera {
        public Vector2 Offset { get; set; }
        public float RotationalOffset { get; set; }
        public Vector2 Origin { get; set; }

        public Camera() {
            this.Offset = new Vector2(0, 0);
            this.RotationalOffset = 0;
            this.Origin = new Vector2(0, 0);
        }
    }
}
