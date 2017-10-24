﻿using Jambo.Producer.Application.Queries;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;

namespace Jambo.Producer.Infrastructure.Queries
{
    public class SchoolQueries : ISchoolQueries
    {
        private readonly IMongoDatabase database;
        public IMongoCollection<ExpandoObject> Schools
        {
            get
            {
                return database.GetCollection<ExpandoObject>("Schools");
            }
        }

        public SchoolQueries(string connectionString, string databaseName)
        {
            MongoClient mongoClient = new MongoClient(connectionString);
            this.database = mongoClient.GetDatabase(databaseName);
        }

        public async Task<IEnumerable<ExpandoObject>> GetSchoolsAsync()
        {
            return await Schools.Find(e => true).ToListAsync();
        }

        public async Task<ExpandoObject> GetSchoolAsync(Guid id)
        {
            return await Schools.Find(Builders<ExpandoObject>.Filter.Eq("_id", id)).SingleAsync();
        }

        public Task<ExpandoObject> GetTeacherAsync(Guid schoolId, Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ExpandoObject> GetChildAsync(Guid schoolId, Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ExpandoObject> GetParentAsync(Guid schoolId, Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
