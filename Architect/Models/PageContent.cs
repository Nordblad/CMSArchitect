namespace Architect.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PageContent")]
    public partial class PageContent
    {
        public int PageId { get; set; }

        public int ContentId { get; set; }

        [StringLength(50)]
        public string Location { get; set; }

        public int PageContentId { get; set; }

        public virtual Content Content { get; set; }

        public virtual Page Page { get; set; }
    }
}
