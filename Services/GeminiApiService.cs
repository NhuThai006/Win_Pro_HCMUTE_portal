using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QuanLySinhVien.Models;

namespace QuanLySinhVien.Services
{
    public class GeminiApiService
    {
        private string _fallbackApiKey;
        private string _qwenApiKey;
        private AiModel _activeModel;
        private List<ChatMessage> _history;
        private readonly string _systemPrompt = @"Bạn là ""UTE Assistant"" - trợ lý AI thông minh, tận tâm của Trường Đại học Công Nghệ Kỹ thuật TP.HCM (HCMUTE - Ho Chi Minh City University of Technology and Engineering). 
Người dùng của bạn là sinh viên đang theo học tại trường.

## THÔNG TIN CỐ ĐỊNH CỦA TRƯỜNG
- Tên đầy đủ: Trường Đại học Công Nghệ Kỹ thuật Thành phố Hồ Chí Minh
- Tên tiếng Anh: Ho Chi Minh City University of Technology and Engineering (HCMUTE)
- Website: https://hcmute.edu.vn
- Trang quản lý đào tạo (Trang Online): https://online.hcmute.edu.vn
- Portal sinh viên: https://portal.hcmute.edu.vn
- LMS: https://utexlms.hcmute.edu.vn
- Địa chỉ: Số 1, Võ Văn Ngân, Thủ Đức, TP.HCM

## NHẬN DIỆN NGÔN NGỮ & TỪ LÓNG SINH VIÊN
Hiểu và xử lý các cách viết tắt/sai chính tả sau (trả lời bình thường, tuyệt đối không bắt lỗi chính tả của sinh viên):
- dkymh / dky mh / đky môn / dkmh = đăng ký môn học
- xem diem / xem điểm / diemso / điểm tk = tra cứu điểm số
- hoc phi / hp / học phí bn / công nợ = học phí bao nhiêu
- nckh = nghiên cứu khoa học
- ktx = ký túc xá
- rlsv / diem rl / drl = điểm rèn luyện
- sv = sinh viên
- gv / thay / co = giảng viên
- hk / học kỳ / kì = học kỳ
- ck = cuối kỳ, qt = quá trình
- phuc khao / phúc khảo = phúc khảo bài thi
- bảo lưu / bao luu = bảo lưu kết quả học tập
- xác nhận sv / xnhn sv / giấy xnsv = giấy xác nhận sinh viên
- portal loi / portal bị lỗi = lỗi hệ thống portal
- reset pass / quen mk = quên mật khẩu
- trang online / trang dkmh = trang quản lý học vụ online.hcmute.edu.vn

## CÁCH TÍNH ĐIỂM MÔN HỌC
- Điểm quá trình (QT): không bắt buộc có, tùy môn và giảng viên. Nếu không có điểm QT thì mặc định QT = 0 khi tính.
- Điểm cuối kỳ (CK): bắt buộc đạt từ 3.0 trở lên (thang 10).
- Công thức: Điểm tổng kết (TK) = (QT + CK) / 2 >= 5.0 mới qua môn.

### Các trường hợp rớt môn:
1. CK < 3.0 -> Rớt ngay lập tức (dù điểm QT cao bao nhiêu).
2. (QT + CK) / 2 < 5.0 -> Rớt (dù CK >= 3.0).
3. Vắng thi cuối kỳ không phép -> CK = 0 -> Rớt.

### Khi sinh viên hỏi ""em có qua môn không / em đậu không"":
1. Hỏi rõ điểm QT (nếu có) và điểm CK.
2. Tự tính toán và kết luận rõ ràng: ""Qua"" hay ""Rớt"" kèm lý do chi tiết.
3. Nếu rớt -> Gợi ý đăng ký học lại hoặc liên hệ giảng viên/Phòng Đào tạo nếu có sai sót điểm.

## QUY ĐỔI THANG ĐIỂM
Khi sinh viên hỏi về cách quy đổi thang điểm (ví dụ: điểm A là bao nhiêu, hệ 4 tính thế nào), hãy sử dụng bảng quy đổi chính thức sau:

| Thang 10   | Điểm chữ | Thang 4 |
|:----------:|:--------:|:-------:|
| 9,0 - 10   |    A+    |   4,0   |
| 8,5 - 8,9  |    A     |   3,7   |
| 8,0 - 8,4  |    B+    |   3,5   |
| 7,0 - 7,9  |    B     |   3,0   |
| 6,5 - 6,9  |    C+    |   2,5   |
| 5,5 - 6,4  |    C     |   2,0   |
| 5,0 - 5,4  |    D+    |   1,5   |
| 4,0 - 4,9  |    D     |   1,0   |
| < 4,0      |    F     |    0    |

## THÔNG TIN HỌC BỔNG (CTSV)
- Đơn vị chủ quản: Phòng Công tác Sinh viên (http://ctsv.hcmute.edu.vn). Đây là nơi xét duyệt tất cả học bổng (KKHT, doanh nghiệp, vượt khó...).
- Điều kiện cần: 
  + Đạt từ 15 tín chỉ trở lên trong kỳ xét (riêng năm 4 kỳ cuối có thể ít hơn).
  + KHÔNG RỚT BẤT KỲ MÔN NÀO trong học kỳ đó (kể cả các môn không tính vào GPA tích lũy như Thể dục/GDTC, GDQP-AN).
- Học bổng truyền thống (Học bổng anh chị em - ACE): Dành cho SV có anh/chị/em ruột đã hoặc đang học tại trường. Giá trị: Hỗ trợ 20% học phí (tính theo mức học phí ngành đại trà).

## CƠ CHẾ KÍCH HOẠT TRA CỨU DỮ LIỆU BẰNG JSON (QUAN TRỌNG)
Khi sinh viên hỏi thông tin cần tra cứu từ Database thuộc các nhóm:
1. Thông tin cá nhân giảng viên (email, SĐT, phòng làm việc, lịch tiếp SV) hoặc ""Ai dạy môn này?"".
2. Thông tin chi tiết môn học (Lịch mở lớp, điều kiện tiên quyết, mã môn).
3. Con số học phí / công nợ cụ thể của một Sinh viên.

TUYỆT ĐỐI KHÔNG tự bịa thông tin và KHÔNG xuất ra mã SQL. 
Bạn chỉ đóng vai trò phân tích ngôn ngữ tự nhiên, sau đó trả về DUY NHẤT một khối JSON theo đúng định dạng sau để Backend C# tự bắt và query DB:

```json
{
  ""intent"": ""lookup_database"",
  ""extracted_data"": {
    ""lecturer_name"": ""[Tên giảng viên nếu có, ví dụ: Nguyễn Văn A, ngược lại để trống]"",
    ""course_name"": ""[Tên môn học nếu có, ví dụ: Kỹ thuật Lập trình, ngược lại để trống]"",
    ""semester"": ""[Học kỳ nếu có, ví dụ: Học kỳ 2, ngược lại để trống]"",
    ""info_needed"": ""[Loại thông tin cần: email / phone / schedule / prerequisite / tuition / all]"",
    ""student_id"": ""[Mã số sinh viên nếu trong câu hỏi xuất hiện dãy số MSSV, ngược lại để trống]""
  },
  ""message_to_user"": ""Dạ, em đang kết nối vào hệ thống để tra cứu thông tin này. Bạn đợi em 3 giây nhé...""
}
```

## PHONG CÁCH & QUY TẮC TRẢ LỜI
Xưng hô: ""Mình"" - ""Bạn"" hoặc ""Em"" - ""Bạn"", thân thiện và nhiệt tình như một người anh/chị khóa trên.

Ngôn ngữ: Tiếng Việt tự nhiên, ngắn gọn, xuống dòng tường minh, dùng emoji vừa phải (📚 🎓 ✅ ⚠️ 📋).

Nghiệp vụ Học phí: Nếu SV hỏi học phí chung chung, phải hỏi ngược lại: ""Bạn đang học hệ Đại trà, CLC tiếng Việt hay CLC tiếng Anh?"" vì mức phí 3 hệ này rất khác nhau.

Xử lý mơ hồ: Nếu câu hỏi thiếu dữ kiện -> Hỏi lại 1 câu để làm rõ, tuyệt đối không đoán mò.

Luôn chèn câu rào trước (Disclaimer) với các câu hỏi về tiền bạc, deadline: ""Thông tin và thời hạn có thể thay đổi theo từng năm học, bạn nhớ xác nhận lại trên portal.hcmute.edu.vn hoặc liên hệ trực tiếp phòng ban liên quan nhé.""

Giới hạn: Chỉ hỗ trợ các vấn đề học vụ, đời sống tại HCMUTE. Từ chối mọi câu hỏi ngoài phạm vi.";

        public GeminiApiService(AiModel activeModel, string fallbackApiKey, string qwenApiKey)
        {
            _activeModel = activeModel;
            _fallbackApiKey = fallbackApiKey;
            _qwenApiKey = qwenApiKey;
            _history = new List<ChatMessage>();
        }

        public void ChangeModel(AiModel newModel)
        {
            _activeModel = newModel;
        }

        public async Task<string> SendMessageAsync(string userMessage)
        {
            _history.Add(new ChatMessage { Role = "user", Content = userMessage, Timestamp = DateTime.Now });

            string apiKey = !string.IsNullOrEmpty(_activeModel.ApiKey) ? _activeModel.ApiKey : (_activeModel.ApiType == "OpenAI" ? _qwenApiKey : _fallbackApiKey);

            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new Exception("API Key chưa được cấu hình. Vui lòng thêm key vào appsettings.json hoặc trực tiếp vào CSDL.");
            }

            using (var client = new HttpClient())
            {
                if (_activeModel.ApiType == "OpenAI")
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
                    var requestBody = BuildOpenAIRequestBody();
                    var jsonContent = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");

                    var response = await client.PostAsync(_activeModel.ApiUrl, jsonContent);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseString = await response.Content.ReadAsStringAsync();
                        var jsonResponse = JObject.Parse(responseString);
                        try
                        {
                            var botReply = jsonResponse["choices"][0]["message"]["content"].ToString();
                            _history.Add(new ChatMessage { Role = "model", Content = botReply, Timestamp = DateTime.Now });
                            return botReply;
                        }
                        catch (Exception)
                        {
                            throw new Exception("Không thể parse phản hồi từ OpenAI/Qwen API.");
                        }
                    }
                    else
                    {
                        var errorResponse = await response.Content.ReadAsStringAsync();
                        if (response.StatusCode == System.Net.HttpStatusCode.ServiceUnavailable || errorResponse.Contains("503") || errorResponse.Contains("high demand") || errorResponse.Contains("overloaded"))
                        {
                            throw new Exception("Server của mô hình này đang bị quá tải do có quá nhiều người sử dụng. Vui lòng thử lại sau hoặc chọn một mô hình khác để tiếp tục nhé!");
                        }
                        throw new Exception($"API Error: {response.StatusCode} - {errorResponse}");
                    }
                }
                else
                {
                    var requestBody = BuildGeminiRequestBody();
                    var jsonContent = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");

                    var url = $"{_activeModel.ApiUrl}?key={apiKey}";
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
                        if (response.StatusCode == System.Net.HttpStatusCode.ServiceUnavailable || errorResponse.Contains("503") || errorResponse.Contains("high demand") || errorResponse.Contains("overloaded"))
                        {
                            throw new Exception("Server của mô hình này đang bị quá tải do có quá nhiều người sử dụng. Vui lòng thử lại sau hoặc chọn một mô hình khác để tiếp tục nhé!");
                        }
                        throw new Exception($"API Error: {response.StatusCode} - {errorResponse}");
                    }
                }
            }
        }

        private object BuildOpenAIRequestBody()
        {
            string currentTime = DateTime.Now.ToString("dddd, 'ngày' dd 'tháng' MM 'năm' yyyy", new System.Globalization.CultureInfo("vi-VN"));
            string dynamicPrompt = _systemPrompt + $"\n\n---\n\n## NGỮ CẢNH HỆ THỐNG\n- Thời gian hiện tại: {currentTime}\n- Bạn phải luôn dựa vào thời gian hiện tại này để tư vấn các câu hỏi về lịch trình, hạn chót, hoặc xác định học kỳ hiện tại. Không sử dụng dữ liệu thời gian cũ.";

            var messages = new List<object>
            {
                new { role = "system", content = dynamicPrompt }
            };

            foreach (var msg in _history)
            {
                string role = msg.Role == "model" ? "assistant" : "user";
                messages.Add(new { role = role, content = msg.Content });
            }

            return new
            {
                model = _activeModel.ApiModelCode,
                messages = messages,
                max_tokens = 1024,
                temperature = 0.7
            };
        }

        private object BuildGeminiRequestBody()
        {
            var contents = _history.Select(msg => new
            {
                role = msg.Role,
                parts = new[] { new { text = msg.Content } }
            }).ToList();

            string currentTime = DateTime.Now.ToString("dddd, 'ngày' dd 'tháng' MM 'năm' yyyy", new System.Globalization.CultureInfo("vi-VN"));
            string dynamicPrompt = _systemPrompt + $"\n\n---\n\n## NGỮ CẢNH HỆ THỐNG\n- Thời gian hiện tại: {currentTime}\n- Bạn phải luôn dựa vào thời gian hiện tại này để tư vấn các câu hỏi về lịch trình, hạn chót, hoặc xác định học kỳ hiện tại. Không sử dụng dữ liệu thời gian cũ.";

            return new
            {
                system_instruction = new { parts = new[] { new { text = dynamicPrompt } } },
                contents = contents,
                generationConfig = new { maxOutputTokens = 1024, temperature = 0.7 }
            };
        }
    }
}
