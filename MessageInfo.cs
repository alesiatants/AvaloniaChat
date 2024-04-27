using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat
{
    public class MessageInfo
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public TimeSpan Date { get; set; } = DateTime.Now.TimeOfDay;
        public string Context { get; set; } = string.Empty;
        public int Id_u { get; set; }

        // Текстовое представление строки таблицы
        public override string ToString()
        {
            return $"{Name}  :  {Date}  -  {Context}";
        }
    }
}
