using System;
using System.Collections.Generic;
using needle_tracker.Models;
using needle_tracker.Repositories;

namespace needle_tracker.Services
{
	public class EntriesService
	{
		#region Service Config
		private readonly EntriesRepository _repo;
		public EntriesService(EntriesRepository repo)
		{
			_repo = repo;
		}
		#endregion

		public IEnumerable<Entry> Get()
		{
			return _repo.Get();
		}

		public Entry Get(int id)
		{
			Entry exists = _repo.Get(id);
			if (exists == null) { throw new Exception("Invalid Id"); }
			return exists;
		}

		public Entry Post(Entry newEntry)
		{
			// Attach timestamp
			newEntry.TimeStamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");

			int id = _repo.Post(newEntry);
			newEntry.Id = id;
			return newEntry;
		}

		public string Void(int id)
		{
			Entry entry = Get(id); //nullcheck here
			_repo.Void(id);
			return "Successfully voided.";
		}
	}
}