using UnityEngine;

public class EffectPlayerController : MonoBehaviour {
    public static EffectPlayerController Instance { get; private set; } // Singleton instance

    [SerializeField] private ParticleSystem buffEffect;
    [SerializeField] private ParticleSystem healEffect;

    private void Awake() {
        // Đảm bảo chỉ có một instance tồn tại
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void Buff() {
        if (buffEffect != null) {
            buffEffect.Clear();  // Xóa hiệu ứng cũ
            buffEffect.Play();   // Chạy lại hiệu ứng buff
            // Dừng hiệu ứng sau thời gian duration của particle
            Invoke(nameof(StopBuffEffect), buffEffect.main.duration);
        }
    }

    public void Heal() {
        if (healEffect != null) {
            healEffect.Clear();  // Xóa hiệu ứng cũ
            healEffect.Play();   // Chạy lại hiệu ứng heal
            // Dừng hiệu ứng sau thời gian duration của particle
            Invoke(nameof(StopHealEffect), healEffect.main.duration);
        }
    }

    private void StopBuffEffect() {
        if (buffEffect != null) {
            buffEffect.Stop(); // Dừng hiệu ứng buff
        }
    }

    private void StopHealEffect() {
        if (healEffect != null) {
            healEffect.Stop(); // Dừng hiệu ứng heal
        }
    }
}
