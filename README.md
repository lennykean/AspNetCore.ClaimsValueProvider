# AspNetCore.ClaimsValueProvider

The claims value provider allows binding a controller parameter to a claim that is associated with the current user, such a user ID, name, or email

## Usage

#### project.json

```json
{
  "dependencies": {
    "AspNetCore.ClaimsValueProvider": "1.0.0",
  }
}
```

#### Startup.cs

Configure the application to use the value provider.

```csharp

public void ConfigureServices(IServiceCollection services)
{
    services.AddMvc(options =>
    {
        options.ValueProviderFactories.Add(new ClaimsValueProviderFactory());
    });
}
```

#### Controller

In a controller action, use the FromClaim attribute, along with a claim type, to bind the parameter

```csharp
public class MyController : Controller
{
    [HttpGet("")]
    public IActionResult Get(
        [FromClaim(ClaimTypes.NameIdentifier)]Guid userId, 
        [FromClaim(ClaimTypes.Email)]string email)
    {
        ...
    }
}
```
