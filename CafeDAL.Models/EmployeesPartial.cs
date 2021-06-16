using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeDAL.Models
{
    public partial class Employees
    {
		public override string ToString()
		{
			// Since the PetName column could be empty, supply
			// the default name of **No Name**.
			return $"{this.FirstName ?? "**No Name**"} {LastName} with Passport ID {PassportId} and INN {INN}.";
		}
	}
}
