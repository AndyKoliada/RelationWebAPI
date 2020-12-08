using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/infrastructure-persistence-layer-design
/// </summary>


namespace WebAPI.Core.Repositories
{
    interface IRepository<T> : IDisposable
    where T : class
        {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
        void Save();
    }
}
