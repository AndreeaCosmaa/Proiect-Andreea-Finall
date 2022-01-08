using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;
namespace Pharmacy3.Models
{
    public class CategorieList
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [ForeignKey(typeof(Medicament))]
        public int MedicamentID { get; set; }
        public int CategorieID { get; set; }
    }
}
