using System;
namespace backend_hannahoney.Models.Media
{
	public class MediaAsset: BaseEntity
	{
        public string? Url { get; set; }      // https://cdn/.../jarrah-500g.jpg
        public int Width { get; set; }       // ví dụ 1600
        public int Height { get; set; }      // ví dụ 1200
        public string? Alt { get; set; }
        public string? TypeMedia { get; set; } = "image";
    }
}

