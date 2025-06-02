using BranchPromotion.Infrastructure.Repositories.Abstracts;
using System.Data;

namespace BranchPromotion.Infrastructure.Repositories.Concretes;

public class ConnectionProvider : IConnectionProvider, IDisposable
{
    private readonly Func<IDbConnection> _connectionFactory;

    private IDbConnection _connection;

    public ConnectionProvider(Func<IDbConnection> connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public IDbConnection Connection
    {
        get
        {
            if (_connection != null)
                return _connection;

            CreateConnection();
            return _connection;
        }
    }

    private void CreateConnection()
    {
        _connection = _connectionFactory();

        if (_connection.State == ConnectionState.Broken)
            _connection.Close();
        if (_connection.State == ConnectionState.Closed)
            _connection.Open();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposing)
            return;
        if (_connection == null)
            return;

        _connection.Dispose();
        _connection = null;
    }
}
