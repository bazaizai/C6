using System;
using System.Collections.Generic;

namespace AppData.Models
{
    public partial class Role
    {
        public Guid Id { get; set; }
        public string Ten { get; set; }
        public int TrangThai { get; set; }
        public virtual List<User> Users { get; set; }
    }
}
