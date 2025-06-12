using System.Runtime.CompilerServices;
using System.Text;
using CloudNative.CloudEvents;
using CloudNative.CloudEvents.SystemTextJson;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/v1/feedbacks", (CancellationToken cancellationToken) => TypedResults.ServerSentEvents(GetFeedbacksAsync(cancellationToken)));

await app.RunAsync();

return;

async IAsyncEnumerable<string> GetFeedbacksAsync([EnumeratorCancellation] CancellationToken cancellationToken)
{
    await foreach (var index in Enumerable.Range(1, 10_000).ToAsyncEnumerable())
    {
        var @event = new CloudEvent
        {
            Id = Guid.NewGuid().ToString(),
            Type = "cloud.native.araraquara.feedbacks.v1",
            Source = new Uri("https://api.cloudnativeararaquara.com/v1/feedbacks"),
            Time = DateTime.UtcNow,
            DataContentType = "application/json",
            Subject = index.ToString(),
            Data = new { FeedbackId = Guid.CreateVersion7(), Content = $"Feedback message {index}" }
        };

        var bytes = new JsonEventFormatter().EncodeStructuredModeMessage(@event, out _);
        yield return Encoding.UTF8.GetString(bytes.Span);
        await Task.Delay(1_000, cancellationToken);
    }
}