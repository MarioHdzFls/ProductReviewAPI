using ProductReviewAPI.Interfaces;
using ProductReviewAPI.Services;
public class AIProviderFactory
{
    private readonly IServiceProvider _serviceProvider;

    public AIProviderFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IAIProvider GetProvider(string providerName)
    {
        return providerName switch
        {
            "Simulated" => _serviceProvider.GetRequiredService<SimulatedAIProvider>(),
            "External" => _serviceProvider.GetRequiredService<ExternalAIProvider>() as IAIProvider ?? throw new InvalidCastException("ExternalAIProvider no implementa IAIProvider."),
            _ => throw new ArgumentException($"Proveedor {providerName} no encontrado.")
        };
    }
}
