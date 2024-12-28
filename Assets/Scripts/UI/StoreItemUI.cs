using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class StoreItemUI : MonoBehaviour {
    public Item BaseItem;                     // Thông tin vật phẩm cơ bản
    [SerializeField] private Image Image;         // Hình ảnh vật phẩm
    [SerializeField] private TextMeshProUGUI itemName; // Tên vật phẩm
    [SerializeField] private List<Sprite> star;   // Các sprite sao (đánh giá hoặc trạng thái)
    [SerializeField] private GameObject horizontal;
    [SerializeField] private GameObject starBuyUI;
   
    private void Start() {
        InitItem();
    }

    void InitItem() {
        if (BaseItem != null) {
            // Gán thông tin cơ bản
            Image.sprite = BaseItem.image;
            itemName.text = FormatItemName(BaseItem.name);

            // Lấy trạng thái từ PlayerPrefs
            int purchasedStatus = PlayerPrefs.GetInt(BaseItem.itemName);

            // Xác định số lượng nút sao tối đa
            int maxStars = 3;
            if (BaseItem.itemName == "Speedy Cape" ||
                BaseItem.itemName == "Crit Value" ||
                BaseItem.itemName == "Lifesteal Necklace" ||
                BaseItem.itemName == "Fireball" ||
                BaseItem.itemName == "Impact Belt" ||
                BaseItem.itemName == "Sword" ||
                BaseItem.itemName == "Wolf" 
                ) {
                maxStars = 1;
            }

            // Khởi tạo tối đa maxStars nút sao
            for (int i = 0; i < maxStars; i++) {
                GameObject starBtn = Instantiate(starBuyUI, horizontal.transform.position, horizontal.transform.rotation, horizontal.gameObject.transform);
                int coinsBuy = (i + 1) * 30;

                // Lấy component StarBuyUI
                StarBuyUI starUI = starBtn.GetComponent<StarBuyUI>();
                starUI.item = BaseItem;

                if (i < purchasedStatus) {
                    // Nếu trạng thái đã mua (>= 1), khởi tạo với star[0]
                    starUI.init(star[0], coinsBuy);
                } else {
                    // Nếu chưa mua, khởi tạo với star[1]
                    starUI.init(star[1], coinsBuy);
                }
            }
        }
    }


    // Hàm lưu trạng thái mua vật phẩm
    public void PurchaseItem() {
        if (BaseItem != null) {

        }
    }

    private string FormatItemName( string name ) {
        // Thay thế dấu gạch dưới bằng khoảng trắng
        name = name.Replace("_", " ");

        // Thêm khoảng trắng trước các chữ cái viết hoa, trừ chữ cái đầu tiên
        for (int i = 1; i < name.Length; i++) {
            if (char.IsUpper(name[i])) {
                name = name.Insert(i, " ");
                i++; // Bỏ qua ký tự vừa thêm để tránh lặp
            }
        }

        // Chuyển chữ cái đầu tiên thành viết hoa
        return char.ToUpper(name[0]) + name.Substring(1).ToLower();
    }
}
