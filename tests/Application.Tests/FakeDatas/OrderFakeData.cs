using Application.Tests.FakeDatas.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tests.FakeDatas;

public class OrderFakeData :BaseFakeData<Order>
{
	public override List<Order> FakeData()
	{
		List<Order> datas = new()
		{
			new Order
			{
				Id = Guid.NewGuid(),
				Name = "Fake 1",
				CreatedDate = DateTime.UtcNow,
				LastUpdatedDate = DateTime.UtcNow
			},

			new Order
			{
				Id = Guid.NewGuid(),
				Name = "Fake 2",
				CreatedDate = DateTime.UtcNow,
				LastUpdatedDate = DateTime.UtcNow
			}
			
		};
		return datas;
	}



}

