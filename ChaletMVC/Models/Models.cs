using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ChaletMVC.Models
{
    public class ChaletDb:DbContext
    {
        public DbSet<Chalet> Chalets { get; set; }
        public DbSet<Guest> Guests { get; set; }

        public ChaletDb():base("ChaletConnection")
        {
            
        }
    }

    public class DatabaseInitializer:DropCreateDatabaseAlways<ChaletDb>
    {
        protected override void Seed(ChaletDb context)
        {
            // Edelweiss Chalet
            Guest g = new Guest
                {
                    GuestName = "Jack",
                    FromDate = DateTime.Parse("2-3-12"), ToDate = DateTime.Parse("4-5-12")
                };
            Chalet c = new Chalet {ChaletName = "Edelweiss", ChaletManager = "Martine"};
            c.Guests = new List<Guest>{g};
            context.Chalets.Add(c);
            // Crow's Nest
            context.Chalets.Add(new Chalet
                {
                    ChaletName = "Crow's Nest",
                    ChaletManager = "Norris",
                    Guests = new List<Guest> {new Guest {GuestName = "Conor"}}
                });
        }
    }

    public class Chalet
    {
        [Key, Required]
        public int ChaletId { get; set; }
        [Required,Display(Name="Chalet"),
                MaxLength(100, ErrorMessage = "Must be <{1} characters")]
        public string ChaletName { get; set; }
        [Display(Name="Mgr")]
        public string ChaletManager { get; set; }
        // Navigation property using lazy loading
        public virtual List<Guest> Guests { get; set; }
    }   // end class

    public class Guest
    {
        public int GuestId { get; set; }
        [Required,MaxLength(10, ErrorMessage = "Must be <{1} characters")]
        public string GuestName { get; set; }
        [DataType(DataType.Date)]
        public DateTime? FromDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? ToDate { get; set; }
        public int ChaletId { get; set; }
        // Navigation property
        public Chalet Chalet { get; set; }
    }
}   // end namespace