using System;

namespace MaritimeTravel.Source.GameComponents {
    class Health {
        private int currentHealth;
        public int MaxHealth { get; set; }

        public Health() {
            this.MaxHealth = 100;
            this.currentHealth = MaxHealth;
        }

        public Health(int maxHealth) {
            this.MaxHealth = maxHealth;
            this.currentHealth = MaxHealth;
        }

        public Health(int maxHealth, int currentHealth) {
            this.MaxHealth = maxHealth;
            SetHealth(currentHealth);
        }

        public void SetHealth(int health) {
            currentHealth = Math.Clamp(health, 0, MaxHealth);
        }

        public void AddHealth(int health) {
            SetHealth(currentHealth + health);
        }

        public void TakeHealth(int health) {
            SetHealth(currentHealth - health);
        }

        public int GetCurrentHealth() {
            return currentHealth;
        }
        public float GetNormalizedHealth() {
            return currentHealth / MaxHealth;
        }

        public float GetNormalizedHealth(int range) {
            return GetNormalizedHealth() * range;
        }

        public bool IsDead() {
            return (currentHealth <= 0);
        }

        public void Kill() {
            SetHealth(0);
        }
    }
}
