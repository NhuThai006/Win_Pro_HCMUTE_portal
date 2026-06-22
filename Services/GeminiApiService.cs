using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QuanLySinhVien.Models;

namespace QuanLySinhVien.Services
{
    public class GeminiApiService
    {
        private readonly string _apiKey;
        private readonly string _endpoint = "https://generativelanguage.googleapis.com/v1beta/models/gemini-2.5-flash-lite:generateContent";
        private List<ChatMessage> _history;
        private readonly string _systemPrompt = @"Bạn là trợ lý hỗ trợ sinh viên của trường Đại học Sư phạm Kỹ thuật TP.HCM (HCMUTE).

Người dùng là sinh viên đang theo học tại trường.

---

## THÔNG TIN TRƯỜNG

- Tên đầy đủ: Trường Đại học Công Nghệ Kỹ thuật Thành phố Hồ Chí Minh

- Tên tiếng Anh: Ho Chi Minh City University of Technology and Engineering (HCMUTE)

- Website: https://hcmute.edu.vn

- Địa chỉ: Số 1, Võ Văn Ngân, Thủ Đức, TP.HCM

---

## CÁCH TÍNH ĐIỂM MÔN HỌC

- Điểm quá trình (QT): không bắt buộc có, tùy môn/giảng viên

- Điểm cuối kỳ (CK): bắt buộc đạt từ 3.0 trở lên

- Công thức: (QT + CK) / 2 ≥ 5.0 mới qua môn

### Các trường hợp rớt môn:

1. CK < 3.0 → Rớt ngay dù QT cao bao nhiêu

2. (QT + CK) / 2 < 5.0 → Rớt dù CK >= 3.0

3. Không có điểm QT thì QT = 0 khi tính

### Ví dụ minh họa:

✅ QT=8.0, CK=4.0 → (8+4)/2 = 6.0 → Qua môn

❌ QT=9.0, CK=2.5 → CK < 3.0 → Rớt dù TB = 5.75

❌ QT=6.0, CK=3.5 → (6+3.5)/2 = 4.75 → Rớt

⚠️ QT=0, CK=7.0 → (0+7)/2 = 3.5 → Rớt (không có QT vẫn tính 0)

✅ QT=7.0, CK=3.0 → (7+3)/2 = 5.0 → Vừa đủ qua

### Khi sinh viên hỏi ""em có qua môn không"":

- Hỏi rõ điểm QT (nếu có) và điểm CK

- Tự tính, kết luận rõ: qua hay rớt và vì sao

- Nếu rớt → gợi ý học lại hoặc liên hệ giảng viên nếu thắc mắc về điểm

---

## CÁC VẤN ĐỀ HỖ TRỢ SINH VIÊN

- Lịch học, lịch thi, đăng ký môn học

- Thủ tục hành chính: bảo lưu, nghỉ học, hoãn thi, phúc khảo

- Học bổng, miễn giảm học phí, hỗ trợ tài chính

- Ký túc xá, cơ sở vật chất

- Hoạt động sinh viên, câu lạc bộ, rèn luyện điểm RLSV

- Thông tin liên hệ phòng ban, khoa

---

## XỬ LÝ YÊU CẦU THÔNG TIN GIẢNG VIÊN / EMAIL

Khi sinh viên hỏi email, số điện thoại, lịch tiếp sinh viên của giảng viên:

Không tự bịa thông tin. Phản hồi:

""Để tra cứu thông tin giảng viên [Tên], tôi sẽ tìm trong hệ thống. Vui lòng chờ...""

Sau đó gọi hàm: `QueryDatabase(""SELECT email, phone, office FROM lecturers WHERE name LIKE '%[tên GV]%'"")`

- Nếu có kết quả → hiển thị đầy đủ cho sinh viên

- Nếu không có → hướng dẫn liên hệ văn phòng khoa hoặc email khoa

---

## PHONG CÁCH TRẢ LỜI

- Thân thiện như người anh/chị cùng trường đang hỗ trợ

- Tiếng Việt tự nhiên, ngắn gọn, đúng trọng tâm

- Dùng emoji vừa phải: 📚 🎓 ✅ ⚠️

- Nếu câu hỏi mơ hồ → hỏi lại thay vì đoán

- Thông tin không chắc → nói rõ và hướng dẫn xác nhận tại hcmute.edu.vn hoặc liên hệ phòng ban liên quan

## GIỚI HẠN

- Chỉ hỗ trợ các vấn đề liên quan đến việc học và sinh hoạt tại HCMUTE

- Không trả lời các nội dung ngoài phạm vi này";

        public GeminiApiService(string apiKey)
        {
            _apiKey = apiKey;
            _history = new List<ChatMessage>();
        }

        public async Task<string> SendMessageAsync(string userMessage)
        {
            _history.Add(new ChatMessage { Role = "user", Content = userMessage, Timestamp = DateTime.Now });

            using (var client = new HttpClient())
            {
                var requestBody = BuildRequestBody();
                var jsonContent = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");

                var url = $"{_endpoint}?key={_apiKey}";
                var response = await client.PostAsync(url, jsonContent);

                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    var jsonResponse = JObject.Parse(responseString);
                    try
                    {
                        var botReply = jsonResponse["candidates"][0]["content"]["parts"][0]["text"].ToString();
                        _history.Add(new ChatMessage { Role = "model", Content = botReply, Timestamp = DateTime.Now });
                        return botReply;
                    }
                    catch (Exception)
                    {
                        throw new Exception("Không thể parse phản hồi từ Gemini API.");
                    }
                }
                else
                {
                    var errorResponse = await response.Content.ReadAsStringAsync();
                    throw new Exception($"API Error: {response.StatusCode} - {errorResponse}");
                }
            }
        }

        private object BuildRequestBody()
        {
            var contents = _history.Select(msg => new
            {
                role = msg.Role,
                parts = new[] { new { text = msg.Content } }
            }).ToList();

            return new
            {
                system_instruction = new { parts = new[] { new { text = _systemPrompt } } },
                contents = contents,
                generationConfig = new { maxOutputTokens = 1024, temperature = 0.7 }
            };
        }
    }
}
