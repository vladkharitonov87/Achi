//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Achi.Data.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserGroup
    {
        public System.Guid ID { get; set; }
        public int Order { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public System.Guid UserID { get; set; }
        public System.Guid PermissionGroupID { get; set; }
        public bool Allow { get; set; }
        public System.Guid CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public System.Guid LastModifiedBy { get; set; }
        public System.DateTime LastModifiedOn { get; set; }
    
        public virtual PermissionGroup PermissionGroup { get; set; }
        public virtual User User { get; set; }
    }
}