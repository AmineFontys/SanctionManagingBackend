﻿namespace SanctionManagingBackend.DAL.Interface
{
    public interface IGenericRepository <T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(int id);
        Task SaveAsync();
    }
}