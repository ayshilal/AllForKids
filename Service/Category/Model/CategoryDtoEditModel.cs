﻿
using Service.Base;

namespace Service.Category.Model
{
    public class CategoryDtoEditModel : BaseDtoEditModel
    {
        public long ID { get; set; }
        public string Type { get; set; }
        public string Slug { get; set; }
        public string Path { get; set; }
        public string Image { get; set; }
        public int Items { get; set; }
    }
}
