using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityAuthentication.Data
{
    public class WorkItemViewModel
    {
        [Required]
        public string Title { get; set; }

        [DisplayName("Requirement description")]
        public string Description { get; set; }

        [Required]
        [DisplayName("Name")]
        public string UserName { get; set; }

        [DisplayName("Email Address")]
        public string UserEmail { get; set; }

        [Required]
        [DisplayName("Mobile")]
        public string UserPhone { get; set; }

        public bool IsSuccess { get; set; }

#nullable enable
        public List<IFormFile>? Files { get; set; }

        public IEnumerable<WorkItem>? WorkItems { get; set; }
    }
}