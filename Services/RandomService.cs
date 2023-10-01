using System;

namespace ProvaPub.Services
{
	public class RandomService
	{
        private readonly Random _randomService;
        public RandomService()
		{
            _randomService = new Random(Guid.NewGuid().GetHashCode());
        }
		public int GetRandom()
		{
            return _randomService.Next(1, 101);
        }

	}
}
