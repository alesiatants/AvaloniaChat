using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Postgrest.Attributes;
using Postgrest.Models;

namespace Chat
{
    [Table("Users")]
    public class UserRow: BaseModel
    {

        [PrimaryKey("id")] public int Id { get; set; }
        [Column("Name")] public string Name { get; set; } = string.Empty;
        [Column("Email")] public string Email { get; set; } = string.Empty;
        [Column("Password")] public string Password { get; set; } = string.Empty;

        // Текстовое представление строки таблицы
        public override string ToString()
        {
            return $"{Id} {Name} {Email}";
        }

    }
}
