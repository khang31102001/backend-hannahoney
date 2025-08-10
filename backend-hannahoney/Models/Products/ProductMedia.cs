using System;
using backend_hannahoney.Models.Media;

namespace backend_hannahoney.Models.Products
{
	public class ProductMedia: BaseEntity
	{

        // relationship product
        public Guid ProductId { get; set; }
        public virtual Product? product { get; set; }

        // relationship media
        public Guid MediaAssetId { get; set; }
        public virtual MediaAsset?  MediaAsset { get; set; }
    }
}

