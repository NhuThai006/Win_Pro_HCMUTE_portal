using System;

namespace QuanLySinhVien.Models
{
    public class AiModel
    {
        public int Id { get; set; }
        public string ModelName { get; set; }
        public string ApiType { get; set; }
        public string ApiUrl { get; set; }
        public string ApiModelCode { get; set; }
        public string ApiKey { get; set; }
        public bool IsActive { get; set; }
    }
}
