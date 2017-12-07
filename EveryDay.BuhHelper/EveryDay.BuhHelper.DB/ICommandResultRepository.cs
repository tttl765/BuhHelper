using EveryDay.BuhHelper.DB.Models;
using System;
using System.Collections.Generic;

namespace EveryDay.BuhHelper.DB
{
    /// <summary>
    /// Сущность - класс, который может храниться в БД
    /// </summary>
    public interface IEntity
    {
        Guid Uid { get; set; }
    }

    /// <summary>
    /// Интерфейс хранилища сущности
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IEntityRepository<T> where T: IEntity
    {
        /// <summary>
        /// Сохранить сущность в бд
        /// </summary>
        /// <param name="result"></param>
        /// <returns>True, если удалось сохранить запись. False - ошибка</returns>
        bool Save(T result);

        T Load(Guid uid);

        T Load(string search);

        IList<T> GetAll();
    }

    public interface ICommandResultRepository : IEntityRepository<CommandResult>
    {
    }

    public interface IUserRepository : IEntityRepository<User>
    {
        User Find(string login, string password);
    }

    public interface ICommandRepository : IEntityRepository<Command>
    {
    }
}
