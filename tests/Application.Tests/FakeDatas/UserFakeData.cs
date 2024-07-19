using Application.Tests.FakeDatas.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


	public class UserFakeData :BaseFakeData<User>
	{
	public override List<User> FakeData()
	{
		List<User> datas = new()
		{
			new User
			{
				Id = Guid.NewGuid(),
				Name = "Fake 1",
				Description = "Fake 1",
				CreatedDate = DateTime.UtcNow,
				LastUpdatedDate = DateTime.UtcNow
			},
			new User
			{
				Id = Guid.NewGuid(),
				Name = "Fake 2",
				Description = "Fake 2",
				CreatedDate = DateTime.UtcNow,
				LastUpdatedDate = DateTime.UtcNow
			}
		};
		return datas;
	}

}

