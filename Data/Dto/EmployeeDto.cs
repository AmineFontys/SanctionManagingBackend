using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanctionManagingBackend.Data.Dto
{
    [Table("Employee")]
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string UserRole { get; set; }

        public enum Role
        {
            Admin,
            User
        }


    }
}
