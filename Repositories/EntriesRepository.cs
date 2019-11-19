using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using needle_tracker.Models;

namespace needle_tracker.Repositories
{
	public class EntriesRepository
	{
		#region Repository Config
		private readonly IDbConnection _db;
		public EntriesRepository(IDbConnection db)
		{
			_db = db;
		}
		#endregion

		public IEnumerable<Entry> Get()
		{
			string sql = "SELECT * FROM entries WHERE isVoid = 0";
			return _db.Query<Entry>(sql);
		}

		public Entry Get(int id)
		{
			string sql = "SELECT * FROM entries WHERE id = @id";
			return _db.QueryFirstOrDefault<Entry>(sql, new { id });
		}

		public int Post(Entry newEntry)
		{
			string sql = @"
				INSERT INTO entries
				(id, timestamp, needlesIn, needlesOut, isVoid, userId)
				VALUES
				(@Id, @TimeStamp, @NeedlesIn, @NeedlesOut, @IsVoid, @UserId);
				SELECT LAST_INSERT_ID();";
			return _db.ExecuteScalar<int>(sql, newEntry);
		}

		public void Void(int id)
		{
			string sql = @"
				UPDATE entries
				SET
					isVoid = !isVoid
				WHERE id = @id;";
			_db.Execute(sql, new { id });
		}
	}
}