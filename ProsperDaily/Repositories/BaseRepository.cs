using ProsperDaily.Abstractions;
using SQLite;
using SQLiteNetExtensions.Extensions;
using System.Linq.Expressions;

namespace ProsperDaily.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : TableData, new()
    {
        SQLiteConnection _connection;
        public string StatusMessage { get; set; }

        public BaseRepository()
        {
            _connection = new SQLiteConnection(Constants.DatabasePath, Constants.Flags);
            _connection.CreateTable<T>();
        }

        public void DeleteItem(T item)
        {
            try
            {
                //_connection.Delete(item);
                _connection.Delete(item, true);
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
        }

        public void Dispose()
        {
            _connection.Close();
        }

        public T GetItem(int id)
        {
            try
            {
                return _connection.Table<T>().FirstOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                StatusMessage =
                     $"Error: {ex.Message}";
            }
            return null;
        }

        public T GetItem(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return _connection.Table<T>().Where(predicate).FirstOrDefault();
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
            return null;
        }

        public List<T> GetItems()
        {
            try
            {
                return _connection.Table<T>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
            return null;
        }

        public List<T> GetItems(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return _connection.Table<T>().Where(predicate).ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
            return null;
        }

        public void SaveItem(T item)
        {
            int result = 0;
            try
            {
                if (item.Id != 0)
                {
                    result = _connection.Update(item);
                    StatusMessage = $"{result} row(s) updated";
                }
                else
                {
                    result = _connection.Insert(item);
                    StatusMessage = $"{result} row(s) added";
                }

            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
        }

        public void SaveItemWithChildren(T item, bool recursive = false)
        {
            _connection.InsertWithChildren(item, recursive);
        }

        public List<T> GetItemsWithChildren()
        {
            try
            {
                return _connection.GetAllWithChildren<T>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
            return null;
        }
    }

}
