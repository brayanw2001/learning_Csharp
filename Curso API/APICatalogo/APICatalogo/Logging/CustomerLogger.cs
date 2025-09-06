
namespace APICatalogo.Logging
{
    public class CustomerLogger : ILogger
    {
        readonly string loggerName;
        readonly CustomLoggerProviderConfiguration loggerConfig;

        public CustomerLogger(string name, CustomLoggerProviderConfiguration config)
        {
            loggerName = name;
            loggerConfig = config;
        }

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel == loggerConfig.LogLevel;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            string mensagem = $"{logLevel.ToString()}: {eventId} - {formatter(state, exception)}";
            
            EscreverTextoNoArquivo(mensagem);
        }

        private void EscreverTextoNoArquivo(object mensagem)
        {
            string caminhoArquivoLog = @"C:\Users\braya\OneDrive\Documentos\logs\logs.txt";

            using (StreamWriter steamWriter = new StreamWriter(caminhoArquivoLog, true))
            {
                try
                {
                    steamWriter.WriteLine(mensagem);
                    steamWriter.Close();
                }
                catch(Exception)
                {
                    throw;
                }
            }
        }
    }
}
