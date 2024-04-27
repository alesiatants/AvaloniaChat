using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Postgrest.Attributes;
using Postgrest.Models;

namespace Chat
{
    [Table("Message")]
    public class MessageRow: BaseModel
    {
        [PrimaryKey("id")] public int Id { get; set; }
        [Column("created_at")] public TimeSpan Date { get; set; } = DateTime.Now.TimeOfDay;
        [Column("Context")] public string Context { get; set; } = string.Empty;
        [Column("id_user")] public int Id_user { get; set; }

        // Текстовое представление строки таблицы
        public override string ToString()
        {
            return $"{Id} {Date} {Context}";
        }
    }
}
