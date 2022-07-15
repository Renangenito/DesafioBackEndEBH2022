using DesafioBackEndEBH2022.Dados;
using DesafioBackEndEBH2022.Extensoes;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigurarServicos();
builder.Services.ConfigurarSwagger();
builder.Services.ConfigurarJWT();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

DadosSemente.Criar(app);

app.Run();
