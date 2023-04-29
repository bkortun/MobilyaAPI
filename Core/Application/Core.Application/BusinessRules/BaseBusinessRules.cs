using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.BusinessRules
{
    public class BaseBusinessRules<TRepository, TEntity> where TRepository : class, IAsyncRepository<TEntity>
        where TEntity : Entity,new()
    {
        private readonly TRepository _repository;

        public BaseBusinessRules(TRepository repository)
        {
            _repository = repository;
        }
        public async Task<TEntity> CheckRequestedIsNotNull(string id)
        {
            if (IsGuid(id))
            {
                TEntity? entity = await _repository.GetAsync(predicate: p => p.Id == Guid.Parse(id));

                if (entity == null)
                    throw new Exception("Böyle bir veri mevcut değil!");

                return entity;
            }
            throw new Exception("Id formatı yanlış!");
        }
        private bool IsGuid(string input)
        {
            if (input == null)
                return false;

            return Guid.TryParse(input, out _);
        }
    }
}
