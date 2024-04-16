public interface IDamageable {
    int getCurrentHealth();
    int getMaxHealth();
    void damage(int amount);
}
