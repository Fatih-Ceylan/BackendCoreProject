using GCrm.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Core.UtilityDomain.Entities;

namespace GCrm.Domain.Entities.Definitions.ProductManagement.Products
{
    public  class Product : BaseEntity
    {
        public ProductServiceEnum  ProductServiceEnum { get; set; }
        public Guid ProductMainCategoryId { get; set; }
        public Guid ProductSubCategoryId { get; set; }
        public Guid ProductTypeId { get; set; }
        public Guid ProductBrandId { get; set; }
        public Guid ProductModelId { get; set; }
        public Guid ProductManufacturerId { get; set; }

        public Guid ProductCategoryId { get; set; }
        public ProductMainCategory  ProductMainCategory { get; set; }
        public ProductSubCategory  ProductSubCategory { get; set; }
        public ProductCategory  ProductCategory { get; set; }
        public string  ProductCode { get; set; }
        public string  ProductName { get; set; }
        public string ProductShortName { get; set; }
        public string ForeignName { get; set; } //yabancı adı
        public ProductType  ProductType { get; set; }
        public string EANNo { get; set; }
        public string UPCCode { get; set; }
        public BarcodeTypeEnum  BarcodeTypeEnum { get; set; }
        public string Description { get; set; }
        public ProductBrand  ProductBrand { get; set; } //marka
        public ProductModel  ProductModel { get; set; } //model
        public ProductManufacturer  ProductManufacturer { get; set; } //üretici fırma
        public string ManufacturerCode { get; set; }
        public string  Origin { get; set; }
        public int PropductDimensions { get; set; } //ürün boyutları
        public int PiecesBox { get; set; } //kolı içi adet 
        public string WarehouseLocationCode { get; set; } // depo yer kodu
        public WorkingConditionEnum  WorkingConditionEnum { get; set; } //çalışma kondisyonu
        public ProductStatuEnum  ProductStatuEnum { get; set; }
        public DateTime ProductCreatedDate { get; set; }
        public ProductUnitEnum   ProductUnitEnum { get; set; } //birim
        public int  StandartCost { get; set; } //standart maliyet
        public CurrencyTypeEnum  CurrencyTypeEnum { get; set; }
        public int PurchasePrice { get; set; } // alış fıyatı
        public int SpecialPurchasePrice { get; set; } // özel alış fıyatı
        public int PurchaseDiscount { get; set; } //alış ıskonto
        public int SalePrice { get; set; }
        public int SalePriceA { get; set; }
        public int SalePriceB { get; set; }
        public int SalePriceC { get; set; }
        public int SalePriceD { get; set; }
        public int SalesDiscount { get; set; } //satış ıskonto
        public ProductKdvEnum  ProductKdvEnum { get; set; }
        public string? FilePath { get; set; }
    }
}
