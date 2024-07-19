using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
	public interface ICacheService
	{
		T GetAll<T>(string key);
		void Remove(string key);
		void Set<T>(string key, T value, TimeSpan expiration);
	}

}
