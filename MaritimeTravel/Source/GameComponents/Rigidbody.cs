using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaritimeTravel.Source.GameComponents {
    class Rigidbody {
        const float WATER_VISC = 0.01f; //PI (poiseuille)
        public float Mass { get; set; }
        public float RadiusProfile { get; set; }
        public Vector2 Velocity { get; set; }
        public Vector2 Acceleration { get; set; }
        public float AngularVelocity { get; set; }
        public float AngularAcceleration { get; set; }

        public Rigidbody(float mass, float rad) {
            Mass = mass;
            RadiusProfile = rad;
        }

        public void Update(Transform transform, GameTime gameTime) {
            transform.Position += Velocity;
            Velocity += Acceleration * (float)gameTime.ElapsedGameTime.TotalSeconds;
            Velocity -= (Velocity * 6 * (float)Math.PI * WATER_VISC * RadiusProfile); //Stokes Law 
            Acceleration = Vector2.Zero;

            transform.Rotation += AngularVelocity;
            AngularVelocity += AngularAcceleration * (float)gameTime.ElapsedGameTime.TotalSeconds;
            AngularVelocity *= 0.95f;
            AngularAcceleration = 0;
        }

        public void AddForce(Vector2 force) {
            Acceleration += force / Mass;
        }

        public void AddForce(float angularForce) {
            AngularAcceleration += angularForce / Mass;
        }
    }
}
