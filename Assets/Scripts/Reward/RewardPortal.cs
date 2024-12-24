using UnityEngine;
using TMPro;

public class RewardPortal : MonoBehaviour {
    private bool isTrigger = false;
    [SerializeField] private TextMeshProUGUI itemNote;
    private DropItemManager dropItemManager;
    private DropItemStats itemStats;
    private DropItemLevel itemLevel;

    private void Start() {
        dropItemManager = GameObject.FindObjectOfType<DropItemManager>();
        UpdateVisualItem();
    }

    public void UpdateVisualItem() {
        string statText;

        if (itemStats != null && itemStats.itemName == "Sword Cooldown") {
            statText = "-" + itemLevel.bonusStat + "%";
        } else if (itemStats != null) {
            statText = "+" + itemLevel.bonusStat;
        } else {
            statText = "";
        }

        itemNote.text = (itemStats != null ? itemStats.itemName : "Unknown Item") + "\n" + statText;
    }

    public void GetDropItemStats( DropItemType type ) {
        itemStats = type.GetRandomDropItemStats();
        itemLevel = itemStats.GetRandomDropItemLevel();
    }

    private void OnTriggerEnter( Collider other ) {
        if (other.gameObject.CompareTag("Player") && !isTrigger) {
            Debug.Log("Đã nhặt dropitem");
            isTrigger = true;

            // Gọi hiệu ứng Buff từ Singleton
            EffectPlayerController.Instance?.Buff();

            // Cập nhật item và phá hủy đối tượng
            dropItemManager.UpdateItem(itemStats, itemLevel.bonusStat);
            Destroy(gameObject, 0.15f);
        }
    }
}
