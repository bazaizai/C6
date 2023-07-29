using System;
using System.Collections.Generic;

namespace AppData.Models
{
    public partial class User
    {
        public Guid Id { get; set; }
        public Guid IdRole { get; set; }
        public string Ma { get; set; }
        public string Ten { get; set; }
        public string DiaChi { get; set; }
        public string Sdt { get; set; }
        public string MatKhau { get; set; }
        public string Email { get; set; }
        public virtual Role Roles { get; set; }
        public virtual List<Bill> Bills { get; set; }
        public virtual Cart Carts { get; set; }
    }
}
