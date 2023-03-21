using System.Collections.Immutable;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Proyecto_LP4.Client;
using Proyecto_LP4.Client.Managers;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<ICitaManager, CitaManager>();
builder.Services.AddScoped<IFacturaManager, FacturaManager>();
builder.Services.AddScoped<IPacienteManager, PacienteManager>();
builder.Services.AddScoped<ITratamientoManager, TratamientoManager>();
builder.Services.AddScoped<IUsuarioManager, UsuarioManager>();
builder.Services.AddScoped<IUsuarioRolManager, UsuarioRolManager>();

await builder.Build().RunAsync();
