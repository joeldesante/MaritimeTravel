using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaritimeTravel.Source.GameComponents {
    class Rigidbody {
        public float Mass { get; set; }
        public Vector2 Velocity { get; set; }
        public Vector2 Acceleration { get; set; }
        public float AngularVelocity { get; set; }
        public float AngularAcceleration { get; set; }

        public Rigidbody(float mass) {
            Mass = mass;
        }

        public void Update(Transform transform, GameTime gameTime) {
            transform.Position += Velocity;
            Velocity += Acceleration * (float)gameTime.ElapsedGameTime.TotalSeconds;
            Acceleration = Vector2.Zero;

            transform.Rotation += AngularVelocity;
            AngularVelocity += AngularAcceleration * (float)gameTime.ElapsedGameTime.TotalSeconds;
            AngularAcceleration = 0;
        }

        public void AddForce(Vector2 force) {
            Acceleration += force / Mass;
        }
    }
}
