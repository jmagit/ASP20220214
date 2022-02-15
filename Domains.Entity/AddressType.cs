﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Domains.Entities
{
    /// <summary>
    /// Types of addresses stored in the Address table. 
    /// </summary>
    [Table("AddressType", Schema = "Person")]
    [Index(nameof(Name), Name = "AK_AddressType_Name", IsUnique = true)]
    [Index(nameof(Rowguid), Name = "AK_AddressType_rowguid", IsUnique = true)]
    public partial class AddressType
    {
        public AddressType()
        {
            BusinessEntityAddresses = new HashSet<BusinessEntityAddress>();
        }

        /// <summary>
        /// Primary key for AddressType records.
        /// </summary>
        [Key]
        [Column("AddressTypeID")]
        public int AddressTypeId { get; set; }
        /// <summary>
        /// Address type description. For example, Billing, Home, or Shipping.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
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

        [InverseProperty(nameof(BusinessEntityAddress.AddressType))]
        public virtual ICollection<BusinessEntityAddress> BusinessEntityAddresses { get; set; }
    }
}