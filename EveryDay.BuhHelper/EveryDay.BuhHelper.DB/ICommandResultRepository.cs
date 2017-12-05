using EveryDay.BuhHelper.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveryDay.BuhHelper.DB
{
    /// <summary>
    /// Сущность - класс, который может храниться в БД
    /// </summary>
    public interface IEntity
    {
        Guid Uid { get; set; }
    }

    public interface IEntityRepository<T> where T: IEntity
    {
        void Save(T result);

        T Load(Guid uid);

        T Load(string search);
    }

    public interface ICommandResultRepository : IEntityRepository<CommandResult>
    {
    }

    public interface IUserRepository : IEntityRepository<User>
    {
        int Count(string FIO);
    }

    public interface ICommandRepository : IEntityRepository<Command>
    {
    }
}
