#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the FluentMappingGenerator.ttinclude code generation file.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Common;
using System.Collections.Generic;
using Telerik.OpenAccess;
using Telerik.OpenAccess.Metadata;
using Telerik.OpenAccess.Data.Common;
using Telerik.OpenAccess.Metadata.Fluent;
using Telerik.OpenAccess.Metadata.Fluent.Advanced;
using Telerik.OpenAccess.Metadata.Relational;
using TelerikKindergarten.ReportModels;

namespace TelerikKindergarten.MySQL.Data
{

    public partial class TelerikKindergartenMySQLModelMetadataSource : FluentMetadataSource
    {
        
        protected override IList<MappingConfiguration> PrepareMapping()
        {
            List<MappingConfiguration> configurations = new List<MappingConfiguration>();

            var reportMapping = new MappingConfiguration<JsonReportViewModel>();
            reportMapping.MapType(p => new
            {
                Id = p.Id,
                ProductId = p.ProductId,
                ProducerName = p.ProducerName,  
                ProductName = p.ProductName,
                TotalIncomes = p.TotalIncomes,
                TotalQuantitySold = p.TotalQuantitySold
            }).ToTable("JSONReports");
            reportMapping.HasProperty(c => c.Id).IsIdentity();

            configurations.Add(reportMapping);

            return configurations;
        }
        
        protected override void SetContainerSettings(MetadataContainer container)
        {
            container.Name = "TelerikKindergartenMySQLModel";
            container.DefaultNamespace = "TelerikKindergarten.MySQL.Data";
            container.NameGenerator.SourceStrategy = Telerik.OpenAccess.Metadata.NamingSourceStrategy.Property;
            container.NameGenerator.RemoveCamelCase = false;
        }
    }
}
#pragma warning restore 1591
