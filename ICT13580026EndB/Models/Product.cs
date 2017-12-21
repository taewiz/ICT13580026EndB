using System;
using SQLite;
namespace ICT13580026EndB.Models
{
	public class Product
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }


		[MaxLength(100)]
		public string Kind { get; set; }
		public string Brand { get; set; }

        [NotNull]
		public string Version { get; set; }
		public int Year { get; set; }
        public int Mile { get; set; }

		public string Color { get; set; }
        public string Dealer { get; set; }
		public int Phone { get; set; }		
        public int Price { get; set; }
		public string Detail { get; set; }
		public string Province { get; set; }
		

	}
}
