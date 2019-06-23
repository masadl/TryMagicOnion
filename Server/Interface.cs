using MagicOnion;
using MagicOnion.Server;

// define interface as Server/Client IDL.
// implements T : IService<T> and share this type between server and client.
public interface IMyFirstService : IService<IMyFirstService>
{
    // Return type must be `UnaryResult<T>` or `Task<UnaryResult<T>>`.
    // If you can use C# 7.0 or newer, recommend to use `UnaryResult<T>`.
    UnaryResult<int> SumAsync(int x, int y);
}

// implement RPC service to Server Project.
// inehrit ServiceBase<interface>, interface
public class MyFirstService : ServiceBase<IMyFirstService>, IMyFirstService
{
    // You can use async syntax directly.
    public async UnaryResult<int> SumAsync(int x, int y)
    {
        Logger.Debug($"Received:{x}, {y}");

        return x + y;
    }
}