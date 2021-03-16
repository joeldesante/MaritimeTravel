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
        public float Zoom { get; set; }
        public Vector2 GlobalScale { get; set; }

        private float baseViewportWidth;   // In pixels
        private float baseViewportHeight;   // In pixels
        private float targetAspectRatio;

        public Matrix transformation { get; set; }

        public Camera() {
            this.Offset = new Vector2(0, 0);
            this.RotationalOffset = 0;
            this.Origin = new Vector2(0, 0);
            this.Zoom = 1f;
            this.GlobalScale = new Vector2(1f);

            this.baseViewportWidth = 1920;
            this.baseViewportHeight = 1080;
            this.targetAspectRatio = this.baseViewportWidth / this.baseViewportHeight;
        }

        public void CalculateTransformation() {
            Matrix translate_origin = Matrix.CreateTranslation(new Vector3(-Origin.X, -Origin.Y, 0));
            Matrix rotate = Matrix.CreateRotationZ(RotationalOffset);
            Matrix translate_offset = Matrix.CreateTranslation(new Vector3(-Offset.X, -Offset.Y, 0));
            Matrix scale = Matrix.CreateScale(Zoom);

            transformation = Matrix.Multiply(Matrix.Multiply(Matrix.Multiply(translate_origin, rotate), scale), translate_offset);
        }

        public void CalculateGlobalScale(Vector2 viewportDimensions) {

            float currentWidth;
            float currentHeight;

            if (viewportDimensions.X > viewportDimensions.Y) {
                currentWidth = viewportDimensions.X;
                currentHeight = viewportDimensions.X / this.targetAspectRatio;
            } else {
                currentWidth = viewportDimensions.Y * this.targetAspectRatio;
                currentHeight = viewportDimensions.Y;
            }

            GlobalScale = new Vector2(
                currentWidth / this.baseViewportWidth,
                currentHeight / this.baseViewportHeight
            );

            
        }
    }
}
