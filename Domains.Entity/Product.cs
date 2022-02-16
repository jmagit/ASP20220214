﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Domains.Entities.Core;

namespace Domains.Entities
{
    /// <summary>
    /// Products sold or used in the manfacturing of sold products.
    /// </summary>
    [Table("Product", Schema = "Production")]
    [Index(nameof(Name), Name = "AK_Product_Name", IsUnique = true)]
    [Index(nameof(ProductNumber), Name = "AK_Product_ProductNumber", IsUnique = true)]
    [Index(nameof(Rowguid), Name = "AK_Product_rowguid", IsUnique = true)]
    [Index(nameof(Class), Name = "NonClusteredIndex-20210311-114814")]
    public partial class Product : EntityBase
    {
        public Product()
        {
            BillOfMaterialComponents = new HashSet<BillOfMaterial>();
            BillOfMaterialProductAssemblies = new HashSet<BillOfMaterial>();
            ProductCostHistories = new HashSet<ProductCostHistory>();
            ProductInventories = new HashSet<ProductInventory>();
            ProductListPriceHistories = new HashSet<ProductListPriceHistory>();
            ProductProductPhotos = new HashSet<ProductProductPhoto>();
            ProductReviews = new HashSet<ProductReview>();
            ProductVendors = new HashSet<ProductVendor>();
            PurchaseOrderDetails = new HashSet<PurchaseOrderDetail>();
            ShoppingCartItems = new HashSet<ShoppingCartItem>();
            SpecialOfferProducts = new HashSet<SpecialOfferProduct>();
            TransactionHistories = new HashSet<TransactionHistory>();
            WorkOrders = new HashSet<WorkOrder>();
        }

        /// <summary>
        /// Primary key for Product records.
        /// </summary>
        [Key]
        [Column("ProductID")]
        public int ProductId { get; set; }
        /// <summary>
        /// Name of the product.
        /// </summary>
        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre")]
        public string Name { get; set; }
        /// <summary>
        /// Unique product identification number.
        /// </summary>
        [Required]
        [StringLength(25)]
        [Display(Name = "Código")]
        public string ProductNumber { get; set; }
        /// <summary>
        /// 0 = Product is purchased, 1 = Product is manufactured in-house.
        /// </summary>
        [Required]
        public bool? MakeFlag { get; set; }
        /// <summary>
        /// 0 = Product is not a salable item. 1 = Product is salable.
        /// </summary>
        [Required]
        public bool? FinishedGoodsFlag { get; set; }
        /// <summary>
        /// Product color.
        /// </summary>
        [StringLength(15)]
        public string Color { get; set; }
        /// <summary>
        /// Minimum inventory quantity. 
        /// </summary>
        public short SafetyStockLevel { get; set; }
        /// <summary>
        /// Inventory level that triggers a purchase order or work order. 
        /// </summary>
        public short ReorderPoint { get; set; }
        /// <summary>
        /// Standard cost of the product.
        /// </summary>
        [Column(TypeName = "money")]
        [DataType(DataType.Currency)]
        public decimal StandardCost { get; set; }
        /// <summary>
        /// Selling price.
        /// </summary>
        [Column(TypeName = "money")]
        public decimal ListPrice { get; set; }
        /// <summary>
        /// Product size.
        /// </summary>
        [StringLength(5)]
        public string Size { get; set; }
        /// <summary>
        /// Unit of measure for Size column.
        /// </summary>
        [StringLength(3)]
        public string SizeUnitMeasureCode { get; set; }
        /// <summary>
        /// Unit of measure for Weight column.
        /// </summary>
        [StringLength(3)]
        public string WeightUnitMeasureCode { get; set; }
        /// <summary>
        /// Product weight.
        /// </summary>
        [Column(TypeName = "decimal(8, 2)")]
        public decimal? Weight { get; set; }
        /// <summary>
        /// Number of days required to manufacture the product.
        /// </summary>
        public int DaysToManufacture { get; set; }
        /// <summary>
        /// R = Road, M = Mountain, T = Touring, S = Standard
        /// </summary>
        [StringLength(2)]
        public string ProductLine { get; set; }
        /// <summary>
        /// H = High, M = Medium, L = Low
        /// </summary>
        [StringLength(2)]
        public string Class { get; set; }
        /// <summary>
        /// W = Womens, M = Mens, U = Universal
        /// </summary>
        [StringLength(2)]
        public string Style { get; set; }
        /// <summary>
        /// Product is a member of this product subcategory. Foreign key to ProductSubCategory.ProductSubCategoryID. 
        /// </summary>
        [Column("ProductSubcategoryID")]
        public int? ProductSubcategoryId { get; set; }
        /// <summary>
        /// Product is a member of this product model. Foreign key to ProductModel.ProductModelID.
        /// </summary>
        [Column("ProductModelID")]
        public int? ProductModelId { get; set; }
        /// <summary>
        /// Date the product was available for sale.
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime SellStartDate { get; set; }
        /// <summary>
        /// Date the product was no longer available for sale.
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? SellEndDate { get; set; }
        /// <summary>
        /// Date the product was discontinued.
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DiscontinuedDate { get; set; }
        /// <summary>
        /// ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.
        /// </summary>
        [Column("rowguid")]
        public Guid Rowguid { get; set; }
        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }
        [Column("ventas")]
        public int? Ventas { get; set; }

        [ForeignKey(nameof(ProductModelId))]
        [InverseProperty("Products")]
        public virtual ProductModel ProductModel { get; set; }
        [ForeignKey(nameof(ProductSubcategoryId))]
        [InverseProperty("Products")]
        public virtual ProductSubcategory ProductSubcategory { get; set; }
        [ForeignKey(nameof(SizeUnitMeasureCode))]
        [InverseProperty(nameof(UnitMeasure.ProductSizeUnitMeasureCodeNavigations))]
        public virtual UnitMeasure SizeUnitMeasureCodeNavigation { get; set; }
        [ForeignKey(nameof(WeightUnitMeasureCode))]
        [InverseProperty(nameof(UnitMeasure.ProductWeightUnitMeasureCodeNavigations))]
        public virtual UnitMeasure WeightUnitMeasureCodeNavigation { get; set; }
        [InverseProperty(nameof(BillOfMaterial.Component))]
        public virtual ICollection<BillOfMaterial> BillOfMaterialComponents { get; set; }
        [InverseProperty(nameof(BillOfMaterial.ProductAssembly))]
        public virtual ICollection<BillOfMaterial> BillOfMaterialProductAssemblies { get; set; }
        [InverseProperty(nameof(ProductCostHistory.Product))]
        public virtual ICollection<ProductCostHistory> ProductCostHistories { get; set; }
        [InverseProperty(nameof(ProductInventory.Product))]
        public virtual ICollection<ProductInventory> ProductInventories { get; set; }
        [InverseProperty(nameof(ProductListPriceHistory.Product))]
        public virtual ICollection<ProductListPriceHistory> ProductListPriceHistories { get; set; }
        [InverseProperty(nameof(ProductProductPhoto.Product))]
        public virtual ICollection<ProductProductPhoto> ProductProductPhotos { get; set; }
        [InverseProperty(nameof(ProductReview.Product))]
        public virtual ICollection<ProductReview> ProductReviews { get; set; }
        [InverseProperty(nameof(ProductVendor.Product))]
        public virtual ICollection<ProductVendor> ProductVendors { get; set; }
        [InverseProperty(nameof(PurchaseOrderDetail.Product))]
        public virtual ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
        [InverseProperty(nameof(ShoppingCartItem.Product))]
        public virtual ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }
        [InverseProperty(nameof(SpecialOfferProduct.Product))]
        public virtual ICollection<SpecialOfferProduct> SpecialOfferProducts { get; set; }
        [InverseProperty(nameof(TransactionHistory.Product))]
        public virtual ICollection<TransactionHistory> TransactionHistories { get; set; }
        [InverseProperty(nameof(WorkOrder.Product))]
        public virtual ICollection<WorkOrder> WorkOrders { get; set; }
    }
}