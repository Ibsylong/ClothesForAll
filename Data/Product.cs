using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesForAll.Data
{
    public class Color 
    {
        public int ColorId { get; set; }
        public string ColorName { get; set; }
    }
    public class Size
    {
        public int SizeId { get; set; }
        public string SizeName { get; set; }
    }

    public class Image
    {
        public int ImageId { get; set; }
        public string ImageSource { get; set; }

    }
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Color> Colors { get; set; }
        public string Description { get; set; }
        public List<Size> Sizes { get; set; }
        public List<Image> Images { get; set; }
        public int Price { get; set; }
        public int TypeId { get; set; }
        public int CategoryId { get; set; }
    }

    public class ClothesType
    {
        public int ClothesTypeId { get; set; }
        public string ClothesTypeName { get; set; }
        public string Description { get; set; }
    }

    public class Category 
    {
        public int CategoryId { get; set; }
        public string Gender { get; set; }
    }
}
