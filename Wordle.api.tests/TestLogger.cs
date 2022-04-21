using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordle.api.tests
{
    internal class TestLogger<T> : ILogger<T>
    {
        private readonly Stack<TestLoggerScope> _scopes = new();
     
        public List<string> LogEntries { get; private set; } = new List<string>();

        public IDisposable BeginScope<TState>(TState state)
        {
            TestLoggerScope scope = new(this, state);
            _scopes.Push(scope);
            return scope;
        }

        private void PopScope()
        {
            _scopes.Pop();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            if (_scopes.Count > 0)
            {
                LogEntries.Add($"{logLevel}: {string.Join("->", _scopes)}: {state}");
            }
            else
            {
                LogEntries.Add($"{logLevel}: Root: {state}");
            }
        }

        public void Log(string message)
        {
            Log(LogLevel.Debug, new EventId(), message, null, null!);
        }



        internal class TestLoggerScope : IDisposable
        {
            private readonly TestLogger<T> _testLogger;
            private readonly object? _state;
            internal TestLoggerScope(TestLogger<T> logger, object? state)
            {
                _testLogger = logger;
                _state = state;
            }

            public void Dispose()
            {
                _testLogger.PopScope();
            }

            public override string ToString()
            {
                return _state?.ToString() ?? "null";
            }
        }
    }

}
