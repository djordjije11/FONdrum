using FONdrum.API.Registrars;

var builder = WebApplication.CreateBuilder(args);
builder.RegisterServices(typeof(Program));
var app = builder.Build();
app.RegisterMiddlewares();
app.Run();
