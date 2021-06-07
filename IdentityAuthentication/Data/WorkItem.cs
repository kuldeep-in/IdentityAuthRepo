using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityAuthentication.Data
{
    public class WorkItem
    {
        [Column(TypeName = "int")]
        [DisplayName("Id")]
        public int WorkItemId { get; set; }

        [DisplayName("Title")]
        [Column(TypeName = "nvarchar(100)")]
        public string Title { get; set; }

        [DisplayName("Requirement description")]
        public string Description { get; set; }

        [DisplayName("Name")]
        public string UserName { get; set; }

        [DisplayName("Email Address")]
        public string UserEmail { get; set; }

        [DisplayName("Mobile")]
        public string UserPhone { get; set; }

        [Column(TypeName = "bit")]
        public bool IsComplete { get; set; }

        public int StateId { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }

#nullable enable
        //[Column(TypeName = "nvarchar(50)")]
        //public string? BatchId { get; set; }

        //[Column(TypeName = "nvarchar(1000)")]
        //public string? WIDescription { get; set; }

        //public string? PoCommentCreatedBy { get; set; }

        ////[DisplayFormat(DataFormatString = "{0:dd-MMM hh:mm tt}")]
        //public DateTime? PoCommentCreatedOn { get; set; }

        //[DisplayName("Implementation")]
        //public string? DevComment { get; set; }

        //public string? DevCommentCreatedBy { get; set; }

        ////[DisplayFormat(DataFormatString = "{0:dd-MMM hh:mm tt}")]
        //public DateTime? DevCommentCreatedOn { get; set; }

        //[DisplayName("Tester comment")]
        //public string? TestComment { get; set; }

        //public string? TestCommentCreatedBy { get; set; }

        ////[DisplayFormat(DataFormatString = "{0:dd-MMM hh:mm tt}")]
        //public DateTime? TestCommentCreatedOn { get; set; }
    }
}