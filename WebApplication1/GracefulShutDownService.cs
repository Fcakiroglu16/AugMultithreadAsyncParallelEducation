using System.Threading.Channels;
using WebApplication1.Models;

namespace WebApplication1;

public class GracefulShutDownService(Channel<Product> channel) : BackgroundService
{
    public override Task StartAsync(CancellationToken cancellationToken)
    {
        
        channel.Writer.WriteAsync(new Product("Sample Product", 9.99m), cancellationToken);
        return base.StartAsync(cancellationToken);
    }

    public override async Task StopAsync(CancellationToken cancellationToken)
    {
        await foreach (var product in channel.Reader.ReadAllAsync(cancellationToken))
        {
            // save to db;
        }


       
    }


    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await foreach (var product in channel.Reader.ReadAllAsync(stoppingToken))
        {
            // process
        }
       
    }
}