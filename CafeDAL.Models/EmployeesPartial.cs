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
			return $"Employee: [{this.FirstName ?? "**No Name**",10} {LastName,10}] with Passport ID: [{PassportId,10}] and INN: [{INN,10}].";
		}
	}
}
