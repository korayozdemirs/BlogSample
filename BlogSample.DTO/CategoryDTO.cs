﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BlogSample.DTO
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<ArticleDTO> Articles { get; set; }
    }
}
